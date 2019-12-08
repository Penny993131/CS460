using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace HW8.Models.ViewModel
{
    public class DetailsViewModel
    {
        public DetailsViewModel(RaceResult raceresult)
        {

            DateTime meetdate = raceresult.Location.MeetDate;
            MeetDate = meetdate;

            string eventtitle = raceresult.Event.EventTitle;
            EventTitle = eventtitle;

            string location = raceresult.Location.Located;
            Located = location;

            RaceTime = raceresult.RaceTime;


        }

        public DateTime MeetDate { get; private set; }
        public string EventTitle { get; set; }
        public string Located { get; set; }
        public string RaceTime { get; set; }


    }
}


