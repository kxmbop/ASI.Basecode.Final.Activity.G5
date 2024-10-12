using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASI.Basecode.WebApp.Models
{
    public class TicketViewModel
    {
        [JsonPropertyName("Subject")]
        [Required(ErrorMessage = "Subject is required")]
        [MaxLength(30, ErrorMessage = "The subject value cannot exceed 30 characters!")]
        public string Subject { get; set; }

        [JsonPropertyName("Customer Email")]
        [Required(ErrorMessage = "Customer is required")]
        public string SenderEmail { get; set; }
        [JsonPropertyName("Category")]
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }
        [JsonPropertyName("Priority")]
        [Required(ErrorMessage = "Priority is required")]
        public string Priority { get; set; }
        [JsonPropertyName("Status")]
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        [JsonPropertyName("Sender")]
        [Required(ErrorMessage = "Sender is required")]
        public string Sender { get; set; }

        [JsonPropertyName("Description")]
        [Required(ErrorMessage = "Description is required")]
        [MinLength(50, ErrorMessage = "The description value should be atleast 50 characters!")]
        public string Description { get; set; }

        public byte[] Attachment { get; set; }

    }
}
