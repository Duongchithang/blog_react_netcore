using System;
using System.Collections.Generic;

namespace blog_backend.Models;

public partial class Comment
{
    public string? IdPost { get; set; }

    public string IdComment { get; set; } = null!;

    public string? Comments { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Post? IdPostNavigation { get; set; }
}
