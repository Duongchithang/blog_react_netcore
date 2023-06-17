using System;
using System.Collections.Generic;

namespace blog_backend.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Photo { get; set; }

    public double Price { get; set; }

    public int CategoryId { get; set; }

    public float? Rating { get; set; }

    public string? UserId { get; set; }

    public bool? Approved { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<InCart> InCarts { get; set; } = new List<InCart>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual AspNetUser? User { get; set; }
}
