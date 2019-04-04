namespace VaporStore.DataProcessor.DTOs.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class UserImportDto
    {
        [Required]
        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        [Required]
        public int Age { get; set; }

        public CardImportDto[] Cards { get; set; }

    }

    public class CardImportDto
    {
        [Required]
        [RegularExpression(@"^([\d]{4} [\d]{4} [\d]{4} [\d]{4}$)")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{3}$")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }

    }
}
