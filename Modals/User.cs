
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace evenement.Modals
{
    public class User : UserBase
    {
       [Key]
        public Guid Id { get; set; }
        
        
    }
}