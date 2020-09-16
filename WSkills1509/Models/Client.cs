namespace WSkills1509.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string Patronymic { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [StringLength(255)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AdditionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastVisitDate { get; set; }

        public int? VisitsCount { get; set; }
    }
}
