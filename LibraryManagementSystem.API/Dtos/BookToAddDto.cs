namespace LibraryManagementSystem.API.Dtos
{
    public class BookToAddDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
