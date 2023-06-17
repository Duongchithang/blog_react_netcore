using System;
using System.Collections.Generic;

namespace blog_backend.Models;

public partial class Permision
{
    public string IdPermision { get; set; } = null!;

    public string? IdUser { get; set; }

    public bool? Create { get; set; }

    public bool? Update { get; set; }

    public bool? Read { get; set; }

    public bool? Delete { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
