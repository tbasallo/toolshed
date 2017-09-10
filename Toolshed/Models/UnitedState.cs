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
        /// Returns a list of all 50 states
        /// </summary>
        /// <returns></returns>
        public static List<UnitedStates> Get50States()
        {
            List<UnitedStates> states = new List<UnitedStates>()
            {
                new UnitedStates(){Name="Alabama", Abbreviation="AL", Capital="Montgomery"},
                new UnitedStates(){Name="Alaska", Abbreviation="AK", Capital="Juneau"},
                new UnitedStates(){Name="Arizona", Abbreviation="AZ", Capital="Phoenix"},
                new UnitedStates(){Name="Arkansas", Abbreviation="AR", Capital="Little Rock"},
                new UnitedStates(){Name="California", Abbreviation="CA", Capital="Sacramento"},
                new UnitedStates(){Name="Colorado", Abbreviation="CO", Capital="Denver"},
                new UnitedStates(){Name="Connecticut", Abbreviation="CT", Capital="Hartford"},
                new UnitedStates(){Name="Delaware", Abbreviation="DE", Capital="Dover"},
                new UnitedStates(){Name="Florida", Abbreviation="FL", Capital="Tallahassee"},
                new UnitedStates(){Name="Georgia", Abbreviation="GA", Capital="Atlanta"},
                new UnitedStates(){Name="Hawaii", Abbreviation="HI", Capital="Honolulu"},
                new UnitedStates(){Name="Idaho", Abbreviation="ID", Capital="Boise"},
                new UnitedStates(){Name="Illinois", Abbreviation="IL", Capital="Springfield"},
                new UnitedStates(){Name="Indiana", Abbreviation="IN", Capital="Indianapolis"},
                new UnitedStates(){Name="Iowa", Abbreviation="IA", Capital="Des Moines"},
                new UnitedStates(){Name="Kansas", Abbreviation="KS", Capital="Topeka"},
                new UnitedStates(){Name="Kentucky", Abbreviation="KY", Capital="Frankfort"},
                new UnitedStates(){Name="Louisiana", Abbreviation="LA", Capital="Baton Rouge"},
                new UnitedStates(){Name="Maine", Abbreviation="ME", Capital="Augusta"},
                new UnitedStates(){Name="Maryland", Abbreviation="MD", Capital="Annapolis"},
                new UnitedStates(){Name="Massachusetts", Abbreviation="MA", Capital="Boston"},
                new UnitedStates(){Name="Michigan", Abbreviation="MI", Capital="Lansing"},
                new UnitedStates(){Name="Minnesota", Abbreviation="MN", Capital="St. Paul"},
                new UnitedStates(){Name="Mississippi", Abbreviation="MS", Capital="Jackson"},
                new UnitedStates(){Name="Missouri", Abbreviation="MO", Capital="Jefferson City"},
                new UnitedStates(){Name="Montana", Abbreviation="MT", Capital="Helena"},
                new UnitedStates(){Name="Nebraska", Abbreviation="NE", Capital="Lincoln"},
                new UnitedStates(){Name="Nevada", Abbreviation="NV", Capital="Carson City"},
                new UnitedStates(){Name="New Hampshire", Abbreviation="NH", Capital="Concord"},
                new UnitedStates(){Name="New Jersey", Abbreviation="NJ", Capital="Trenton"},
                new UnitedStates(){Name="New Mexico", Abbreviation="NM", Capital="Santa Fe"},
                new UnitedStates(){Name="New York", Abbreviation="NY", Capital="Raleigh"},
                new UnitedStates(){Name="North Carolina", Abbreviation="NC", Capital="Lansing"},
                new UnitedStates(){Name="North Dakota", Abbreviation="ND", Capital="Bismarck"},
                new UnitedStates(){Name="Ohio", Abbreviation="OH", Capital="Columbus"},
                new UnitedStates(){Name="Oklahoma", Abbreviation="OK", Capital="Oklahoma City"},
                new UnitedStates(){Name="Oregon", Abbreviation="OR", Capital="Salem"},
                new UnitedStates(){Name="Pennsylvania", Abbreviation="PA", Capital="Harrisburg"},
                new UnitedStates(){Name="Rhode Island", Abbreviation="RI", Capital="Providence"},
                new UnitedStates(){Name="South Carolina", Abbreviation="SC", Capital="Columbia"},
                new UnitedStates(){Name="South Dakota", Abbreviation="SD", Capital="Pierre"},
                new UnitedStates(){Name="Tennessee", Abbreviation="TN", Capital="Nashville"},
                new UnitedStates(){Name="Texas", Abbreviation="TX", Capital="Austin"},
                new UnitedStates(){Name="Utah", Abbreviation="UT", Capital="Salt Lake City"},
                new UnitedStates(){Name="Vermont", Abbreviation="VT", Capital="Montpelier"},
                new UnitedStates(){Name="Virginia", Abbreviation="VI", Capital="Richmond"},
                new UnitedStates(){Name="Washington", Abbreviation="WA", Capital="Olympia"},
                new UnitedStates(){Name="West Virginia", Abbreviation="WV", Capital="Charleston"},
                new UnitedStates(){Name="Wisconsin", Abbreviation="WI", Capital="Madison"},
                new UnitedStates(){Name="Wisconsin", Abbreviation="WI", Capital="Madison"},
                new UnitedStates(){Name="Wyoming", Abbreviation="WY", Capital="Cheyenne"},
            };

            return states;
        }
    }

}
