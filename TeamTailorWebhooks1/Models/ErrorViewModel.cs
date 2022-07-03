namespace TeamTailorWebhooks1.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class student
    {
        public string? Name { get; set; }
        public string? RollNo { get; set; }



    }
}