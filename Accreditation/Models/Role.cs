using System;
using System.Collections.Generic;

namespace Accreditation.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Roles { get; set; } = null!;

    public string Syncoperation { get; set; } = null!;

    public DateTime Syncversion { get; set; }
}
