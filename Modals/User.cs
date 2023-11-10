
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace evenement.Modals
{
    public class User
    {
       [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;     
        public string? Username {get;set;}= string.Empty;
        public string  Email { get; set; }= string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Role>?  Role { get; set; }
        
    }
}