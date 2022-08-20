using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore_API.Models.Author
{
    public class GetAuthorDto : BaseAuthorDto
    {
        public int Id { get; set; }

    } 
}
