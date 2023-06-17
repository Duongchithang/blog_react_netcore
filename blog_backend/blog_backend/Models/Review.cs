using System;
using System.Collections.Generic;

namespace blog_backend.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public string Text { get; set; } = null!;

    public int Rating { get; set; }

    public string? UserId { get; set; }

    public int? ProductId { get; set; }

    public DateTime Date { get; set; }

    public virtual Product? Product { get; set; }

    public virtual AspNetUser? User { get; set; }
}
