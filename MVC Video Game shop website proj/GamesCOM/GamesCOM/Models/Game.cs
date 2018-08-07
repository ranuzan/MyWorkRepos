using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesCOM.Models
{
    //Game class defenition
    public class Game
    {
        [Key]
        [Required]
        [StringLength(49, MinimumLength = 2, ErrorMessage = "Length must be between 2 and 49 characters")]
        public string name { get; set; }

        [Required]
        [RegularExpression("^(XBOX ONE)|(PC)|(PS4)|(PS3)|(XBOX 360)$", ErrorMessage = "Console type must be: XBOX ONE, XBOX 360, PC, PS3, PS4")]
        public string console { get; set; }

        [Required]
        [StringLength(49, MinimumLength = 2, ErrorMessage = "Length must be between 2 and 49 characters")]
        public string genre { get; set; }

        [Required]
        [RegularExpression ("^[0-9]+$", ErrorMessage = "Please enter numeric amount in Shekels (without Agorot)")]
        public string price { get; set; }

        public string coverLink { get; set; }

        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter numeric amount")]
        public string stock { get; set; }
    }
}