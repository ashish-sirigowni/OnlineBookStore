﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Entity
{
    public class User
    {
        
        [Key] 
        [StringLength(5)] 
        [Column(TypeName = "char")]
        public string? UserID { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Username", TypeName = "varchar")]
        public string? Name { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Email", TypeName = "varchar")]
        public string? Email { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Phone", TypeName = "varchar")]
        public string? Mobile { get; set; }
        [Required]
        [StringLength(10)]
        [Column("Password", TypeName = "varchar")]
        public string? Password { get; set; }
        [Required]
        [StringLength(10)]
        [Column("Role", TypeName = "varchar")]
        public string? Role { get; set; }
        
    }
}
