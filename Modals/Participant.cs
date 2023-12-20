using System.ComponentModel.DataAnnotations;

namespace evenement.Modals
{
    public class Participant : UserBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Status {get; set;} = "En attent";
        public Guid UserId { get; set; }
    }
}