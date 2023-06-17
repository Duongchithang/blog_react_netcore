namespace blog_backend.Models;

public partial class Post
{
    public string IdPost { get; set; } = null!;

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? IdUser { get; set; }

    public string? Category { get; set; }

    public byte[]? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UrlPost { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? IdUserNavigation { get; set; }
}
