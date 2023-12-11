namespace Accreditation.Models
{
    public class AccreditationModels
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}