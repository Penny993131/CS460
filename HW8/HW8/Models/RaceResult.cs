namespace HW8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RaceResult
    {
        public int ID { get; set; }

        [Required]
        [StringLength(256)]
        public string RaceTime { get; set; }

        public int? AthleteID { get; set; }

        public int? TeamID { get; set; }

        public int? MeetID { get; set; }

        public int? LocationID { get; set; }

        public int? EventID { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Event Event { get; set; }

        public virtual Location Location { get; set; }

        public virtual Meet Meet { get; set; }

        public virtual Team Team { get; set; }
    }
}
