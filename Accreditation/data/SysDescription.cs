using System;
using System.Collections.Generic;

namespace Accreditation.data;

public partial class SysDescription
{
    public string TableName { get; set; } = null!;

    public string TableField { get; set; } = null!;

    public string Syncoperation { get; set; } = null!;

    public DateTime Syncversion { get; set; }
}
