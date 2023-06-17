using System;
using System.Collections.Generic;

namespace blog_backend.Models;

public partial class InCart
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
