using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Display(Name = "ФИО")]
        [StringLength(100, ErrorMessage = "Длина не должна превышать 100 символов")]
        [Required(ErrorMessage = "Поле обязательное")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Длина не должна превышать 100 символов")]
        [RegularExpression(@"[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+", ErrorMessage = "Некорректный формат почты")]
        [Required(ErrorMessage = "Поле обязательное")]
        public string Email { get; set; }
        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfCreation { get; set; }
        [Display(Name = "Дата изменения")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfChange { get; set; }
    }
}
