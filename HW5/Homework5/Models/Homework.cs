using System;
using System.ComponentModel.DataAnnotations;


namespace Homework5.Models
{
    public class Homework
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

       

        public override string ToString()
        {
            return $"{base.ToString()}: {Priority} {LastName} {DOB} {Age}";
        }
    }
}