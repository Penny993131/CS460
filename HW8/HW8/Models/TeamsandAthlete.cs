namespace HW8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TeamsandAthlete
    {
        public int ID { get; set; }

        public int? TeamID { get; set; }

        public int? AthleteID { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Team Team { get; set; }
    }
}
