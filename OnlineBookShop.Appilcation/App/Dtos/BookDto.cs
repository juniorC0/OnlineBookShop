namespace OnlineBookShop.Appilcation.App.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
    }
}
