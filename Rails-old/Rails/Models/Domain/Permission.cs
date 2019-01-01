﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rails.Models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }

}