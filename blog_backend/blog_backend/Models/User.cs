using System;
using System.Collections.Generic;

namespace blog_backend.Models;

public partial class User
{
    public string IdUser { get; set; } = null!;

    public string? Username { get; set; }

    public string? Password { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? IsAdmin { get; set; }

    public string? Avartar { get; set; }

    public string? Status { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Permision> Permisions { get; set; } = new List<Permision>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
