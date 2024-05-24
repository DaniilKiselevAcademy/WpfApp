using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id - {StudentId}, Имя - {Name}";
        }
    }
}
