namespace BookStore_API.Data
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float HomeLatitude { get; set; }
        public float HomeLongitude { get; set; }

        public virtual IList<Book> Books { get; set; }

    }
}