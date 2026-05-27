using System.ComponentModel.DataAnnotations;

namespace MonAPIAlphorm.Entities
{
    public class EmailTemplateEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(300)]
        public string? Subject { get; set; }

        [Required]
        public string Body { get; set; } = string.Empty;
    }
}
