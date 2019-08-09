using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.Models.Context
{
    [Table("Subsidiary")]
    public class Subsidiary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "INT")]
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [Column(Order = 3, TypeName = "INT")]
        public int IdCompany { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "VARCHAR(50)")]
        public string NameSubsidiary { get; set; }

        [Required]
        [Column(Order = 5, TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(15)")]
        public string Phone { get; set; }

        [Required]
        [Column(Order = 7, TypeName = "FLOAT")]
        public float AnnualGross { get; set; }

        [Column(Order = 8, TypeName = "DATETIME")]
        public DateTime CreateDate { get; set; }

        [Column(Order = 9, TypeName = "VARCHAR(10)")]
        public string TypeSubsidiary { get; set; }

    }
}
