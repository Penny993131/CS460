using System;
using System.ComponentModel.DataAnnotations;


namespace Homework5.Models
{
    public class Homework
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public NVARCHAR(64) Priority { get; set; }

        [Required]
        public DATETIME DueDate { get; set; }

        [Required]
        public Time DueTime { get; set; }

    [Required]
    public TEXT Department { get; set; }

    [Required]
    public TEXT Course# { get; set; }

    [Required]
    public TEXT Homework Title { get; set; }

    [Required]
    public TEXT Notes { get; set; }



    public override string ToString()
        {
            return $"{base.ToString()}: {Priority} {DueDate} {DueTime} {Department}{Course#}{Homework Title}{Notes}";
        }
    }
}