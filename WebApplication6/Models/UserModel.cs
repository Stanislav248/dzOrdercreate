using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Ім'я є обов'язковим")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Ім'я повинно бути від 5 до 30 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вік є обов'язковим")]
        [Range(1, 100, ErrorMessage = "Вік повинен бути від 1 до 100 років")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Номер телефону є обов'язковим")]
        [Phone(ErrorMessage = "Некоректний формат телефону")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Номер телефону має містити лише цифри")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Пароль є обов'язковим")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Підтвердження пароля є обов'язковим")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Цей рядок є обов'язковим")]
        [RegularExpression(@"^[A-ZА-ЯІЇЄҐ]+$", ErrorMessage = "Тільки великі літери (латиниця або кирилиця)")]
        public string CustomLine { get; set; }
    }
}
