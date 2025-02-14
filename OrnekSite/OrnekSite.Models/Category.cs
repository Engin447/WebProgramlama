﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekSite.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Kategori Adı")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
