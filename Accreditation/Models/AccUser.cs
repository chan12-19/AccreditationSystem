﻿using System;
using System.Collections.Generic;

namespace Accreditation.Models;

public partial class AccUser
{
    public string UserId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? RoleId { get; set; }

    public DateTime CreatedDt { get; set; }

    public string Syncoperation { get; set; } = null!;

    public DateTime Syncversion { get; set; }
}
