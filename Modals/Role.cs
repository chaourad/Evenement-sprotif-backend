
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace evenement.Modals
{
    public class Role
    {
      [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;  
        [NotMapped]
        [JsonIgnore]
        public List<User>? Users {get; set;} 
    }
}