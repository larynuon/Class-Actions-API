using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Class_Actions_API.Models
{
    public enum LandOwner
    {
        [Display(Name ="Not Set")]
        NotSet,
        Yes,
        No
    }

    public enum State
    {
        NSW,
        QLD,
        SA,
        TAS,
        VIC,
        WA
    }

    public class Client
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DOB { get; set; }

        [DisplayName("Address Line 1")]
        [Required]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        public string Suburb { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a State")]
        [Required]
        public State State { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select an Items")]
        [DisplayName("Land Owner")]
        [Required]
        public LandOwner LandOwner { get; set; }

        [DisplayName("Date of LCA")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DOL { get; set; }
                
        public string Comments { get; set; }
                
        public virtual ICollection<Claim> Claims { get; set; }
    }
}
