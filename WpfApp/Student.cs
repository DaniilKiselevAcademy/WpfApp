// Импортирую библиотеки для создания аннотаций
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp
{
    public class Student
    {
        // Создаю первичный ключ и настраиваю автоинкремент
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        // Переопределение поведения при конвертации объекта в строку
        public override string ToString()
        {
            return $"Id - {StudentId}, Имя - {Name}";
        }
    }
}
