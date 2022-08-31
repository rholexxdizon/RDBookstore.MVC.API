using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RDBookstoreMVC2.Models
{
    public partial class Books
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "\u20B1{0}")]   
        public int Price { get; set; }

        [Required]
        [MaxLength(250)]
        public string Overview { get; set; }

       [Required]
        public string Summary { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required,
        DisplayFormat(DataFormatString = "{0} cm"),
        Display(Name = "Length (cm)")]
        public short Length { get; set; }

        [Required,
        DisplayFormat(DataFormatString = "{0} cm"),
        Display(Name = "Width (cm)")]
        public short Width { get; set; }

        [Required,
        DisplayFormat(DataFormatString = "{0} cm"),
        Display(Name = "Height (cm)")]
        public short Height { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Display(Name ="Publication Date"),
        DataType(DataType.Date)]
        public string PublicationDate {get; set; }

        [Required,
        Display(Name ="Image Url"),
        Url]    
        public string ImageUrl { get; set; } 

        [Required,
        Display(Name ="ISBN (13)"),
        MinLength(13),
        MaxLength(13)]
        public string ISBN {get; set; }

        [Required,
        Display(Name = "Sales Rank")]
        public int SalesRank { get; set; }
    }

    
}
