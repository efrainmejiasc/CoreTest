using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.Models.Context
{
    [Table("UserApi")]
    public class UserApi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(200)")]
        public string Password { get; set; }

        [Column(Order = 5, TypeName = "DATETIME")]
        public DateTime CreateDate { get; set; }
    }
}
