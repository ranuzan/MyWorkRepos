using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GamesCOM.Models
{
    //User class defenition
    public class User
    {
        [Key]
        [Required(ErrorMessage ="User Name is requierd")]
        public string userName { get; set; }

        [Required(ErrorMessage ="password is requierd")]
        public string password { get; set; }

        [Required(ErrorMessage = "first name is requierd")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "last name is requierd")]
        public string lastName { get; set; }


        public  int permission { get; set; }


        public Boolean deleted { get; set; }


    }
}