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
        public int IdentityCompany { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(50)")]
        public string NameSubsidiary { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(15)")]
        public string Phone { get; set; }

        [Column(Order = 6, TypeName = "FLOAT")]
        public float AnnualGross { get; set; }

        [Column(Order = 7, TypeName = "DATETIME")]
        public DateTime CreateDate { get; set; }
    }
}
