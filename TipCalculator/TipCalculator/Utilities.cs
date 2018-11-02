namespace TipCalculator
{
    /// <summary>Contains common generic methods used by the program</summary>
    public static class Utilities
    {
        /// <summary>Converts a camel case string to normal text</summary>
        /// <param name="toUnCamel">The string to remove camel case from</param>
        /// <returns>Original string with spaces before caps and all lowercase</returns>
        public static string UnCamelCase(string toUnCamel)
        {
            // Declare a string to return.
            string returnString = "";

            // Cycle through passed string.
            foreach(char character in toUnCamel)
            {
                // Is the character uppercase(start of word)?
                if (char.IsUpper(character))
                {
                    // Append a space before the next character.
                    returnString += " ";
                }

                // Add the character to the return string.
                returnString += toUnCamel[character];
            }

            // Return the lower case version of the string.
            return returnString.ToLower();
        }

        /// <summary>Rounds to the nearest multiple of the passed unit</summary>
        /// <param name="value">The value that will be rounded</param>
        /// <param name="unit">The unit to round to</param>
        /// <returns>The rounded value</returns>
        public static double RoundByUnit(double value, double unit)
        {
            // Is the distance between units greater or less than half the unit?
            if (value % unit < unit / 2)
            {
                // Round down by chopping off the remainder.
                return value - value % unit;
            }
            else
            {
                // Round up by adding the remainder complement.
                return value + (unit - value % unit);
            }
        }
    }
}