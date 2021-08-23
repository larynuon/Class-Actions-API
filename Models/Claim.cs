using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Class_Actions_API.Models
{
    public class Claim
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Names On Policy")]
        [Required]
        public string NamesOnPolicy { get; set; }
        
        [Required]
        public string Insurer { get; set; }

        [DisplayName("Policy Number")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0!")]
        [Required]
        public int PolicyNo { get; set; }

        [DisplayName("Garden/Grounds Cost")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0!")]
        [Required]
        public double GroundsCost { get; set; }

        [DisplayName("Fencing Cost")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0!")]
        [Required]
        public double FencingCost { get; set; }

        [DisplayName("Personal Labour Cost")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0!")]
        [Required]
        public double LabourCost { get; set; }

        [DisplayName("Total Claim Cost")]
        public double TotalClaimCost { get; set; }
        public string Comments { get; set; }

        [ForeignKey("ClientId")]
        public virtual int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
