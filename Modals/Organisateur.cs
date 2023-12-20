
using System.ComponentModel.DataAnnotations;

namespace evenement.Modals
{
    public class Organisateur : UserBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}