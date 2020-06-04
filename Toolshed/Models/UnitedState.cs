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
        /// The main/major time zone for the state
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
                new UnitedStates(){Name="Alabama", Abbreviation="AL", Capital="Montgomery", TimeZone = "Central"},
                new UnitedStates(){Name="Alaska", Abbreviation="AK", Capital="Juneau", TimeZone = "Alaska"},
                new UnitedStates(){Name="Arizona", Abbreviation="AZ", Capital="Phoenix", TimeZone = "USMountain"},
                new UnitedStates(){Name="Arkansas", Abbreviation="AR", Capital="Little Rock",  TimeZone = "Central"},
                new UnitedStates(){Name="California", Abbreviation="CA", Capital="Sacramento",  TimeZone = "Pacific"},
                new UnitedStates(){Name="Colorado", Abbreviation="CO", Capital="Denver",  TimeZone = "Mountain"},
                new UnitedStates(){Name="Connecticut", Abbreviation="CT", Capital="Hartford",  TimeZone = "Central"},
                new UnitedStates(){Name="Delaware", Abbreviation="DE", Capital="Dover",  TimeZone = "Eastern"},
                new UnitedStates(){Name="Florida", Abbreviation="FL", Capital="Tallahassee",  TimeZone = "Eastern"},
                new UnitedStates(){Name="Georgia", Abbreviation="GA", Capital="Atlanta",  TimeZone = "Eastern"},
                new UnitedStates(){Name="Hawaii", Abbreviation="HI", Capital="Honolulu",  TimeZone = "Hawaii"},
                new UnitedStates(){Name="Idaho", Abbreviation="ID", Capital="Boise", TimeZone = "Mountain"},
                new UnitedStates(){Name="Illinois", Abbreviation="IL", Capital="Springfield", TimeZone = "Central"},
                new UnitedStates(){Name="Indiana", Abbreviation="IN", Capital="Indianapolis", TimeZone = "Eastern"},
                new UnitedStates(){Name="Iowa", Abbreviation="IA", Capital="Des Moines", TimeZone = "Central"},
                new UnitedStates(){Name="Kansas", Abbreviation="KS", Capital="Topeka", TimeZone = "Central"},
                new UnitedStates(){Name="Kentucky", Abbreviation="KY", Capital="Frankfort", TimeZone = "Eastern"},
                new UnitedStates(){Name="Louisiana", Abbreviation="LA", Capital="Baton Rouge", TimeZone = "Central"},
                new UnitedStates(){Name="Maine", Abbreviation="ME", Capital="Augusta", TimeZone = "Eastern"},
                new UnitedStates(){Name="Maryland", Abbreviation="MD", Capital="Annapolis", TimeZone = "Eastern"},
                new UnitedStates(){Name="Massachusetts", Abbreviation="MA", Capital="Boston", TimeZone = "Eastern"},
                new UnitedStates(){Name="Michigan", Abbreviation="MI", Capital="Lansing", TimeZone = "Eastern"},
                new UnitedStates(){Name="Minnesota", Abbreviation="MN", Capital="St. Paul", TimeZone = "Central"},
                new UnitedStates(){Name="Mississippi", Abbreviation="MS", Capital="Jackson", TimeZone = "Central"},
                new UnitedStates(){Name="Missouri", Abbreviation="MO", Capital="Jefferson City", TimeZone = "Central"},
                new UnitedStates(){Name="Montana", Abbreviation="MT", Capital="Helena", TimeZone = "Mountain"},
                new UnitedStates(){Name="Nebraska", Abbreviation="NE", Capital="Lincoln", TimeZone = "Mountain"},
                new UnitedStates(){Name="Nevada", Abbreviation="NV", Capital="Carson City", TimeZone = "Pacific"},
                new UnitedStates(){Name="New Hampshire", Abbreviation="NH", Capital="Concord", TimeZone = "Eastern"},
                new UnitedStates(){Name="New Jersey", Abbreviation="NJ", Capital="Trenton", TimeZone = "Eastern"},
                new UnitedStates(){Name="New Mexico", Abbreviation="NM", Capital="Santa Fe", TimeZone = "Mountain"},
                new UnitedStates(){Name="New York", Abbreviation="NY", Capital="Raleigh", TimeZone = "Eastern"},
                new UnitedStates(){Name="North Carolina", Abbreviation="NC", Capital="Lansing", TimeZone = "Eastern"},
                new UnitedStates(){Name="North Dakota", Abbreviation="ND", Capital="Bismarck", TimeZone = "Central"},
                new UnitedStates(){Name="Ohio", Abbreviation="OH", Capital="Columbus", TimeZone = "Eastern"},
                new UnitedStates(){Name="Oklahoma", Abbreviation="OK", Capital="Oklahoma City", TimeZone = "Central"},
                new UnitedStates(){Name="Oregon", Abbreviation="OR", Capital="Salem", TimeZone = "Pacific"},
                new UnitedStates(){Name="Pennsylvania", Abbreviation="PA", Capital="Harrisburg", TimeZone = "Eastern"},
                new UnitedStates(){Name="Rhode Island", Abbreviation="RI", Capital="Providence", TimeZone = "Eastern"},
                new UnitedStates(){Name="South Carolina", Abbreviation="SC", Capital="Columbia", TimeZone = "Eastern"},
                new UnitedStates(){Name="South Dakota", Abbreviation="SD", Capital="Pierre", TimeZone = "Central"},
                new UnitedStates(){Name="Tennessee", Abbreviation="TN", Capital="Nashville", TimeZone = "Central"},
                new UnitedStates(){Name="Texas", Abbreviation="TX", Capital="Austin", TimeZone = "Central"},
                new UnitedStates(){Name="Utah", Abbreviation="UT", Capital="Salt Lake City", TimeZone = "Mountain"},
                new UnitedStates(){Name="Vermont", Abbreviation="VT", Capital="Montpelier", TimeZone = "Eastern"},
                new UnitedStates(){Name="Virginia", Abbreviation="VI", Capital="Richmond", TimeZone = "Eastern"},
                new UnitedStates(){Name="Washington", Abbreviation="WA", Capital="Olympia", TimeZone = "Pacific"},
                new UnitedStates(){Name="WEastern Virginia", Abbreviation="WV", Capital="CharlEasternon", TimeZone = "Eastern"},
                new UnitedStates(){Name="Wisconsin", Abbreviation="WI", Capital="Madison", TimeZone = "Central"},
                new UnitedStates(){Name="Wyoming", Abbreviation="WY", Capital="Cheyenne", TimeZone = "Mountain"},
            };

            return states;
        }
    }

}
