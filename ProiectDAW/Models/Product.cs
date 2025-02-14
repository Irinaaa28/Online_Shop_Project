﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ProiectDAW.Models.ProductBookmarks;

namespace ProiectDAW.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Titlul este obligatoriu")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Descrierea produsului este obligatorie")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Imaginea produsului este obligatorie")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Pretul este obligatoriu")]
        [Range(0.01, 1000000, ErrorMessage = "Pretul trebuie sa fie pozitiv")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Stocul este obligatoriu")]
        [Range(0, 1000000, ErrorMessage = "Stocul trebuie sa fie pozitiv")]
        public int Stock { get; set; }
        //Ratingul trebuie sa fie de la 1 la 5
        //public int? Rating { get; set; }

        [Required(ErrorMessage = "Categoria este obligatorie")]
        public int? CategoryId { get; set; }

        // PASUL 6: useri si roluri
        // cheie externa (FK) - un articol este postat de catre un user
        public string? UserId { get; set; }
        public bool? IsApproved { get; set; } = false;

        //public double? AverageRating { get; set; } // Add this property
        //public List<Review>? Reviews { get; set; } = new List<Review>();

        public virtual Category? Category { get; set; }

        // PASUL 6: useri si roluri
        // proprietate virtuala - un articol este postat de catre un user
        public virtual ApplicationUser? User { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? Categ { get; set; }

        //scorul
        //public int? Score { get; set; }

        public virtual ICollection<ProductBookmark>? ProductBookmarks { get; set; }
        //public virtual ICollection<ShoppingCartItem>? ProductBaskets { get; set; }

    }
}

