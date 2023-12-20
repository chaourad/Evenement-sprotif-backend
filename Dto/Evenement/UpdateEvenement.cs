
namespace evenement.Dto.Evenement
{
    public class UpdateEvenement
    {
        public string Name {get; set;} 
        public string Lieu {get; set;}
        public DateTime DateDebut { get; set; }
        public string Regle { get; set; }
        public int MaxParticipant {get; set; }

    }
}