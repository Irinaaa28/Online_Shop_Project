﻿namespace ProiectDAW.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        //public string UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? PurchaseDate { get; set; }
        //public virtual ApplicationUser User { get; set; }
        public virtual Product? Product { get; set; }
        public decimal? Total { get; set; }
    }

}
