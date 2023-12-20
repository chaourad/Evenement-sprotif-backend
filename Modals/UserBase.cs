using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace evenement.Modals
{
    public class UserBase
    {
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