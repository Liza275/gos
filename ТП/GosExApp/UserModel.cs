using System.ComponentModel.DataAnnotations;

namespace GosExApp
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int ClassId { get; set; }

        public ClassModel ClassModel { get; set; }
    }
}
