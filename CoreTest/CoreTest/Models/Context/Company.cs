﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.Models.Context
{
    [Table("Company")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        int Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR")]
        [StringLength(50)]
        string NameCompany { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR")]
        [StringLength(50)]
        string BusinessBranch { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR")]
        [StringLength(50)]
        string Email { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR")]
        [StringLength(15)]
        string Phone { get; set; }

        [Column(Order = 6, TypeName = "FLOAT")]
        float AnnualGross { get; set; }

        [Column(Order = 7, TypeName = "DATETIME")]
        DateTime CreateDate { get; set; }
    }
}
