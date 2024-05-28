using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GosExApp
{
    public class ClassModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<UserModel> Users { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
