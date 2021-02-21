using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace filed.Domain.Models
{
    public class    PaymentState
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public StatusUnit PaymentStatus { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}