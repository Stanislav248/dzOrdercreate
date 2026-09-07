using System.ComponentModel.DataAnnotations;

namespace OrderApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва є обов'язковою.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Назва повинна бути від 3 до 50 символів.")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Range(1, 10000, ErrorMessage = "Ціна повинна бути від 1 до 10 000.")]
        public decimal Price { get; set; }

        [Range(1, 100, ErrorMessage = "Кількість повинна бути від 1 до 100.")]
        public int Quantity { get; set; }

        public decimal TotalPrice => Price * Quantity;
    }
}
