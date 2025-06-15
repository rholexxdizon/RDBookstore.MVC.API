namespace RDBookstoreAPI.DTOs
{
    public class BookCreateDto
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public string Overview { get; set; }

        public string Summary { get; set; }

        public string Publisher { get; set; }

        public int Pages { get; set; }

        public short Length { get; set; }

        public short Width { get; set; }

        public short Height { get; set; }

        public string Genre { get; set; }

        public string PublicationDate { get; set; }

        public string ImageUrl { get; set; }

        public string ISBN { get; set; }

        public int SalesRank { get; set; }
    }
}
