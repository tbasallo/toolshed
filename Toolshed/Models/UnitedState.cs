using System;
using System.Collections.Generic;
using System.Text;

namespace Toolshed
{
    public class UnitedStates
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Capital { get; set; }

        /// <summary>
        /// The main/mojor time zone for the state
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Returns a list of all 50 states
        /// </summary>
        /// <returns></returns>
        public static List<UnitedStates> Get50States()
        {
            List<UnitedStates> states = new List<UnitedStates>()
            {
                new UnitedStates(){Name="Alabama", Abbreviation="AL", Capital="Montgomery", TimeZone = "CST"},
                new UnitedStates(){Name="Alaska", Abbreviation="AK", Capital="Juneau", TimeZone = "AKST"},
                new UnitedStates(){Name="Arizona", Abbreviation="AZ", Capital="Phoenix", TimeZone = "MST"},
                new UnitedStates(){Name="Arkansas", Abbreviation="AR", Capital="Little Rock",  TimeZone = "CST"},
                new UnitedStates(){Name="California", Abbreviation="CA", Capital="Sacramento",  TimeZone = "PST"},
                new UnitedStates(){Name="Colorado", Abbreviation="CO", Capital="Denver",  TimeZone = "MST"},
                new UnitedStates(){Name="Connecticut", Abbreviation="CT", Capital="Hartford",  TimeZone = "CST"},
                new UnitedStates(){Name="Delaware", Abbreviation="DE", Capital="Dover",  TimeZone = "EST"},
                new UnitedStates(){Name="Florida", Abbreviation="FL", Capital="Tallahassee",  TimeZone = "EST"},
                new UnitedStates(){Name="Georgia", Abbreviation="GA", Capital="Atlanta",  TimeZone = "EST"},
                new UnitedStates(){Name="Hawaii", Abbreviation="HI", Capital="Honolulu",  TimeZone = "HST"},
                new UnitedStates(){Name="Idaho", Abbreviation="ID", Capital="Boise", TimeZone = "MST"},
                new UnitedStates(){Name="Illinois", Abbreviation="IL", Capital="Springfield", TimeZone = "CST"},
                new UnitedStates(){Name="Indiana", Abbreviation="IN", Capital="Indianapolis", TimeZone = "EST"},
                new UnitedStates(){Name="Iowa", Abbreviation="IA", Capital="Des Moines", TimeZone = "CST"},
                new UnitedStates(){Name="Kansas", Abbreviation="KS", Capital="Topeka", TimeZone = "CST"},
                new UnitedStates(){Name="Kentucky", Abbreviation="KY", Capital="Frankfort", TimeZone = "EST"},
                new UnitedStates(){Name="Louisiana", Abbreviation="LA", Capital="Baton Rouge", TimeZone = "CST"},
                new UnitedStates(){Name="Maine", Abbreviation="ME", Capital="Augusta", TimeZone = "EST"},
                new UnitedStates(){Name="Maryland", Abbreviation="MD", Capital="Annapolis", TimeZone = "EST"},
                new UnitedStates(){Name="Massachusetts", Abbreviation="MA", Capital="Boston", TimeZone = "EST"},
                new UnitedStates(){Name="Michigan", Abbreviation="MI", Capital="Lansing", TimeZone = "EST"},
                new UnitedStates(){Name="Minnesota", Abbreviation="MN", Capital="St. Paul", TimeZone = "CST"},
                new UnitedStates(){Name="Mississippi", Abbreviation="MS", Capital="Jackson", TimeZone = "CST"},
                new UnitedStates(){Name="Missouri", Abbreviation="MO", Capital="Jefferson City", TimeZone = "CST"},
                new UnitedStates(){Name="Montana", Abbreviation="MT", Capital="Helena", TimeZone = "MST"},
                new UnitedStates(){Name="Nebraska", Abbreviation="NE", Capital="Lincoln", TimeZone = "MST"},
                new UnitedStates(){Name="Nevada", Abbreviation="NV", Capital="Carson City", TimeZone = "PST"},
                new UnitedStates(){Name="New Hampshire", Abbreviation="NH", Capital="Concord", TimeZone = "EST"},
                new UnitedStates(){Name="New Jersey", Abbreviation="NJ", Capital="Trenton", TimeZone = "EST"},
                new UnitedStates(){Name="New Mexico", Abbreviation="NM", Capital="Santa Fe", TimeZone = "MST"},
                new UnitedStates(){Name="New York", Abbreviation="NY", Capital="Raleigh", TimeZone = "EST"},
                new UnitedStates(){Name="North Carolina", Abbreviation="NC", Capital="Lansing", TimeZone = "EST"},
                new UnitedStates(){Name="North Dakota", Abbreviation="ND", Capital="Bismarck", TimeZone = "CST"},
                new UnitedStates(){Name="Ohio", Abbreviation="OH", Capital="Columbus", TimeZone = "EST"},
                new UnitedStates(){Name="Oklahoma", Abbreviation="OK", Capital="Oklahoma City", TimeZone = "CST"},
                new UnitedStates(){Name="Oregon", Abbreviation="OR", Capital="Salem", TimeZone = "PST"},
                new UnitedStates(){Name="Pennsylvania", Abbreviation="PA", Capital="Harrisburg", TimeZone = "EST"},
                new UnitedStates(){Name="Rhode Island", Abbreviation="RI", Capital="Providence", TimeZone = "EST"},
                new UnitedStates(){Name="South Carolina", Abbreviation="SC", Capital="Columbia", TimeZone = "EST"},
                new UnitedStates(){Name="South Dakota", Abbreviation="SD", Capital="Pierre", TimeZone = "CST"},
                new UnitedStates(){Name="Tennessee", Abbreviation="TN", Capital="Nashville", TimeZone = "CST"},
                new UnitedStates(){Name="Texas", Abbreviation="TX", Capital="Austin", TimeZone = "CST"},
                new UnitedStates(){Name="Utah", Abbreviation="UT", Capital="Salt Lake City", TimeZone = "MST"},
                new UnitedStates(){Name="Vermont", Abbreviation="VT", Capital="Montpelier", TimeZone = "EST"},
                new UnitedStates(){Name="Virginia", Abbreviation="VI", Capital="Richmond", TimeZone = "EST"},
                new UnitedStates(){Name="Washington", Abbreviation="WA", Capital="Olympia", TimeZone = "PST"},
                new UnitedStates(){Name="West Virginia", Abbreviation="WV", Capital="Charleston", TimeZone = "EST"},
                new UnitedStates(){Name="Wisconsin", Abbreviation="WI", Capital="Madison", TimeZone = "CST"},
                new UnitedStates(){Name="Wyoming", Abbreviation="WY", Capital="Cheyenne", TimeZone = "MST"},
            };

            return states;
        }
    }

}
