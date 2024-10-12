using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASI.Basecode.WebApp.Models
{
    public class KnowledgeBaseViewModel
    {
        [JsonPropertyName("Title")]
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30, ErrorMessage = "The title value cannot exceed 30 characters!")]
        public string Title { get; set; }

        [JsonPropertyName("Creator")]
        [Required(ErrorMessage = "Creator is required")]
        public string Creator { get; set; }

        [JsonPropertyName("Content")]
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }

    }
}
