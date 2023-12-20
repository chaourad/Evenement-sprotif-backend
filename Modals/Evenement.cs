using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace evenement.Modals
{
    public class Evenement
    {
        [Key]
        public Guid id {get; set;}
        public string Name {get; set;}
        public string Lieu {get; set;}
        public DateTime DateDebut { get; set; }
        public int MaxParticipant {get; set; }
        public string Regle { get; set; }
        public int NombreParticipantActuel {get; set; }
        public Guid UserId {get; set;}
        public Organisateur? Organisateur {get; set;}
        public List<Participant>? Participants {get; set;}
        public Guid TypeEvnId { get; set; }
        public TypeEvn? TypeEvns { get; set; }
    }
}