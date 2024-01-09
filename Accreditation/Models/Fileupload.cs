using System;
using System.Collections.Generic;

namespace Accreditation.Models;

public partial class Fileupload
{
    public string FileName { get; set; } = null!;

    public string CourseId { get; set; } = null!;

    public byte[] Attachment { get; set; } = null!;

    public string Syncoperation { get; set; } = null!;

    public DateTime Syncversion { get; set; }
}
