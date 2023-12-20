using System.ComponentModel.DataAnnotations;

namespace evenement.Modals
{
    public class TypeEvn
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Urls { get; set; }
    }
}