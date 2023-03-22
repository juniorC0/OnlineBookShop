namespace OnlineBookShop.Domain
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
    }
}
