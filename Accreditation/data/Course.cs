using System;
using System.Collections.Generic;

namespace Accreditation.data;

public partial class Course
{
    public string CourseId { get; set; } = null!;

    public string CourseName { get; set; } = null!;

    public string Faculty { get; set; } = null!;

    public string? CourseDesc { get; set; }

    public DateTime ExpirtyDt { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ApproveDt { get; set; }

    public string Status { get; set; } = null!;

    public DateTime Syncversion { get; set; }

    public string Syncoperation { get; set; } = null!;
}
