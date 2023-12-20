
using evenement.Modals;

namespace evenement.Dto.Evenement
{
    public class CreateEvemenet
    {
        public string Name {get; set;} 
        public string Lieu {get; set;}
        public DateTime DateDebut { get; set; }
        public int MaxParticipant {get; set; }
        public string Regle { get; set; }
        public Guid UserId {get; set;}
        public Organisateur? Organisateur { get; set; } = null;
        public Guid TypeEvnId { get; set; }
    }
}