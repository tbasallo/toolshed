using System.Collections.Immutable;

namespace Toolshed
{
    /// <summary>
    /// Represents a state from the USA
    /// </summary>
    public class UnitedState(string name, string abbreviation, string capital, string timeZone)
    {
        public string Name { get; } = name;
        public string Abbreviation { get; } = abbreviation;
        public string Capital { get; } = capital;

        /// <summary>
        /// The main/major time zone for the state
        /// </summary>
        public string TimeZone { get; } = timeZone;
    }


    /// <summary>
    /// Helper methhods for the United State object
    /// </summary>
    public static class UnitedStates
    {
        /// <summary>
        /// A static copy of the 50 states.
        /// </summary>
        public static readonly List<UnitedState> TheStates =
            [
                new UnitedState("Alabama", "AL", "Montgomery", "Central"),
                new UnitedState("Alaska", "AK", "Juneau", "Alaska"),
                new UnitedState("Arizona", "AZ", "Phoenix", "USMountain"),
                new UnitedState("Arkansas", "AR", "Little Rock",  "Central"),
                new UnitedState("California", "CA", "Sacramento",  "Pacific"),
                new UnitedState("Colorado", "CO", "Denver",  "Mountain"),
                new UnitedState("Connecticut", "CT", "Hartford",  "Central"),
                new UnitedState("Delaware", "DE", "Dover",  "Eastern"),
                new UnitedState("Florida", "FL", "Tallahassee",  "Eastern"),
                new UnitedState("Georgia", "GA", "Atlanta",  "Eastern"),
                new UnitedState("Hawaii", "HI", "Honolulu",  "Hawaii"),
                new UnitedState("Idaho", "ID", "Boise", "Mountain"),
                new UnitedState("Illinois", "IL", "Springfield", "Central"),
                new UnitedState("Indiana", "IN", "Indianapolis", "Eastern"),
                new UnitedState("Iowa", "IA", "Des Moines", "Central"),
                new UnitedState("Kansas", "KS", "Topeka", "Central"),
                new UnitedState("Kentucky", "KY", "Frankfort", "Eastern"),
                new UnitedState("Louisiana", "LA", "Baton Rouge", "Central"),
                new UnitedState("Maine", "ME", "Augusta", "Eastern"),
                new UnitedState("Maryland", "MD", "Annapolis", "Eastern"),
                new UnitedState("Massachusetts", "MA", "Boston", "Eastern"),
                new UnitedState("Michigan", "MI", "Lansing", "Eastern"),
                new UnitedState("Minnesota", "MN", "St. Paul", "Central"),
                new UnitedState("Mississippi", "MS", "Jackson", "Central"),
                new UnitedState("Missouri", "MO", "Jefferson City", "Central"),
                new UnitedState("Montana", "MT", "Helena", "Mountain"),
                new UnitedState("Nebraska", "NE", "Lincoln", "Mountain"),
                new UnitedState("Nevada", "NV", "Carson City", "Pacific"),
                new UnitedState("New Hampshire", "NH", "Concord", "Eastern"),
                new UnitedState("New Jersey", "NJ", "Trenton", "Eastern"),
                new UnitedState("New Mexico", "NM", "Santa Fe", "Mountain"),
                new UnitedState("New York", "NY", "Raleigh", "Eastern"),
                new UnitedState("North Carolina", "NC", "Lansing", "Eastern"),
                new UnitedState("North Dakota", "ND", "Bismarck", "Central"),
                new UnitedState("Ohio", "OH", "Columbus", "Eastern"),
                new UnitedState("Oklahoma", "OK", "Oklahoma City", "Central"),
                new UnitedState("Oregon", "OR", "Salem", "Pacific"),
                new UnitedState("Pennsylvania", "PA", "Harrisburg", "Eastern"),
                new UnitedState("Rhode Island", "RI", "Providence", "Eastern"),
                new UnitedState("South Carolina", "SC", "Columbia", "Eastern"),
                new UnitedState("South Dakota", "SD", "Pierre", "Central"),
                new UnitedState("Tennessee", "TN", "Nashville", "Central"),
                new UnitedState("Texas", "TX", "Austin", "Central"),
                new UnitedState("Utah", "UT", "Salt Lake City", "Mountain"),
                new UnitedState("Vermont", "VT", "Montpelier", "Eastern"),
                new UnitedState("Virginia", "VI", "Richmond", "Eastern"),
                new UnitedState("Washington", "WA", "Olympia", "Pacific"),
                new UnitedState("West Virginia", "WV", "Charleston", "Eastern"),
                new UnitedState("Wisconsin", "WI", "Madison", "Central"),
                new UnitedState("Wyoming", "WY", "Cheyenne", "Mountain"),
            ];



        /// <summary>
        /// Return the state by its 2 letter abbreviation
        /// </summary>
        public static ImmutableDictionary<string, UnitedState> States => TheStates.ToImmutableDictionary(x => x.Abbreviation, x => x);

        /// <summary>
        /// Return the time zone for the specified state by its 2 letter abbreviation
        /// </summary>
        public static ImmutableDictionary<string, string> TimeZones => TheStates.ToImmutableDictionary(x => x.Abbreviation, x => x.TimeZone);



        /// <summary>
        /// Returns a new list of all 50 states
        /// </summary>
        /// <returns></returns>
        public static List<UnitedState> Get50States()
        {
            List<UnitedState> states =
            [
                new UnitedState("Alabama", "AL", "Montgomery", "Central"),
                new UnitedState("Alaska", "AK", "Juneau", "Alaska"),
                new UnitedState("Arizona", "AZ", "Phoenix", "USMountain"),
                new UnitedState("Arkansas", "AR", "Little Rock",  "Central"),
                new UnitedState("California", "CA", "Sacramento",  "Pacific"),
                new UnitedState("Colorado", "CO", "Denver",  "Mountain"),
                new UnitedState("Connecticut", "CT", "Hartford",  "Central"),
                new UnitedState("Delaware", "DE", "Dover",  "Eastern"),
                new UnitedState("Florida", "FL", "Tallahassee",  "Eastern"),
                new UnitedState("Georgia", "GA", "Atlanta",  "Eastern"),
                new UnitedState("Hawaii", "HI", "Honolulu",  "Hawaii"),
                new UnitedState("Idaho", "ID", "Boise", "Mountain"),
                new UnitedState("Illinois", "IL", "Springfield", "Central"),
                new UnitedState("Indiana", "IN", "Indianapolis", "Eastern"),
                new UnitedState("Iowa", "IA", "Des Moines", "Central"),
                new UnitedState("Kansas", "KS", "Topeka", "Central"),
                new UnitedState("Kentucky", "KY", "Frankfort", "Eastern"),
                new UnitedState("Louisiana", "LA", "Baton Rouge", "Central"),
                new UnitedState("Maine", "ME", "Augusta", "Eastern"),
                new UnitedState("Maryland", "MD", "Annapolis", "Eastern"),
                new UnitedState("Massachusetts", "MA", "Boston", "Eastern"),
                new UnitedState("Michigan", "MI", "Lansing", "Eastern"),
                new UnitedState("Minnesota", "MN", "St. Paul", "Central"),
                new UnitedState("Mississippi", "MS", "Jackson", "Central"),
                new UnitedState("Missouri", "MO", "Jefferson City", "Central"),
                new UnitedState("Montana", "MT", "Helena", "Mountain"),
                new UnitedState("Nebraska", "NE", "Lincoln", "Mountain"),
                new UnitedState("Nevada", "NV", "Carson City", "Pacific"),
                new UnitedState("New Hampshire", "NH", "Concord", "Eastern"),
                new UnitedState("New Jersey", "NJ", "Trenton", "Eastern"),
                new UnitedState("New Mexico", "NM", "Santa Fe", "Mountain"),
                new UnitedState("New York", "NY", "Raleigh", "Eastern"),
                new UnitedState("North Carolina", "NC", "Lansing", "Eastern"),
                new UnitedState("North Dakota", "ND", "Bismarck", "Central"),
                new UnitedState("Ohio", "OH", "Columbus", "Eastern"),
                new UnitedState("Oklahoma", "OK", "Oklahoma City", "Central"),
                new UnitedState("Oregon", "OR", "Salem", "Pacific"),
                new UnitedState("Pennsylvania", "PA", "Harrisburg", "Eastern"),
                new UnitedState("Rhode Island", "RI", "Providence", "Eastern"),
                new UnitedState("South Carolina", "SC", "Columbia", "Eastern"),
                new UnitedState("South Dakota", "SD", "Pierre", "Central"),
                new UnitedState("Tennessee", "TN", "Nashville", "Central"),
                new UnitedState("Texas", "TX", "Austin", "Central"),
                new UnitedState("Utah", "UT", "Salt Lake City", "Mountain"),
                new UnitedState("Vermont", "VT", "Montpelier", "Eastern"),
                new UnitedState("Virginia", "VI", "Richmond", "Eastern"),
                new UnitedState("Washington", "WA", "Olympia", "Pacific"),
                new UnitedState("West Virginia", "WV", "Charleston", "Eastern"),
                new UnitedState("Wisconsin", "WI", "Madison", "Central"),
                new UnitedState("Wyoming", "WY", "Cheyenne", "Mountain"),
            ];

            return states;
        }
    }
}
