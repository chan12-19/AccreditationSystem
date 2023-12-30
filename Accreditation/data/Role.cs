using System;
using System.Collections.Generic;

namespace Accreditation.data;

public partial class Role
{
    public string RoleId { get; set; } = null!;

    public string Roles { get; set; } = null!;

    public string Syncoperation { get; set; } = null!;

    public DateTime Syncversion { get; set; }
}
