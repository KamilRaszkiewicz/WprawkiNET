﻿using System.ComponentModel.DataAnnotations;

namespace PB04.Pages.Forms
{
    public class DateForm
    {

        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        [Range(1899, 2022)]
        public int Year { get; set; }
    }
}
