using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RDBookstoreMVC.Models
{
    public partial class Books
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }


        [Required,
        Display(Name = "Author"),
        MaxLength(length: 100)]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Overview")]
        public string Overview { get; set; }

        [Required]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int? Price { get; set; }

        [Required]
        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Required]
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }

        [Required]
        [Display(Name = "Publication Date")]
        public string PublicationDate { get; set; }

        [Required]
        [Display(Name = "Pages")]
        public int? Pages { get; set; }

        [Required]
        [Display(Name = "Length")]
        public int Length { get; set; }

        [Required]
        [Display(Name = "Width")]
        public int Width { get; set; }

        [Required]
        [Display(Name = "Height")]
        public int Height { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public int Weigth { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Sales rank")]
        public int SalesRank { get; set; }
    }
}
