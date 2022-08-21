using AutoMapper;
using BookStore_API.Contracts;
using BookStore_API.Data;
using BookStore_API.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BookStore_API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration; //explained in GenerateToken
        private ApiUser _user;

        private const string _loginProvider = "BookStoreAPI";
        private const string _refreshToken = "RefreshToken";

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateRefreshToken()
        {
            //removes old token, generates a new one, and applies it
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshToken);

            return newRefreshToken;

        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            _user = await _userManager.FindByEmailAsync(loginDto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);
            
            if(_user == null || isValidUser == false)
                return null; //user doesn't exist/password wrong so nothing comes back

            var token = await GenerateToken();
            return new AuthResponseDto
            {
                Token = token,
                UserId = _user.Id,
                RefreshToken = await CreateRefreshToken()
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            _user = _mapper.Map<ApiUser>(userDto); //map dto and API user
            _user.UserName = userDto.Email;
            var result = await _userManager.CreateAsync(_user, userDto.Password); //creating the user via userManager class

            if (result.Succeeded)
            {
                //we add the incoming user to the "user" Role, RBAC
                await _userManager.AddToRoleAsync(_user, "User");
            }

            return result.Errors; //we return errors data type
            //return the errors, regardless of result, even if empty.
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            //getting the token content from the inc request object
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token); //reading the token contents
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
            _user = await _userManager.FindByNameAsync(username); //find username in the user manager

            if (_user == null || _user.Id != request.UserId)
                return null;

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);
            
            if (isValidRefreshToken)
            {
                var token = await GenerateToken();
                return new AuthResponseDto
                {
                    Token = token, //generated token
                    UserId = _user.Id,
                    RefreshToken = await CreateRefreshToken() //gets the value of what gets created in the token
                };
            }

            await _userManager.UpdateSecurityStampAsync(_user); //this happens if the token wasn't valid, and regenerates security stamp
            return null;
        }

        private async Task<string> GenerateToken()
        {
            //this is where we generate the token. 
            //before we do this, we need to know what the symmetric key is (in the configuration)
            //therefore, we need to inject the configuration mnger into here
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            //now we generate credentials using the key
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var roles = await _userManager.GetRolesAsync(_user); //tell me the roles the user has
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList(); //foreach role, give me the claim and add the value from the db

            var userClaims = await _userManager.GetClaimsAsync(_user);
            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email), //the person the token has been issued to
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), 
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("uid", _user.Id),
            }
            .Union(userClaims).Union(roleClaims);
            //we generate the token itself
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32
                    (_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token); //a string that represents our token
        }
    }
}
