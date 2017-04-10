using System.Text.RegularExpressions;

namespace RegularExpressions
{
    /// <summary>
    /// Regex tester: http://regexstorm.net/tester
    /// Regex paradise: http://www.rexegg.com/regex-csharp.html
    /// https://regex101.com/
    /// </summary>
    public class GuessingGame
    {
        public static void Perform()
        {
            RegexIntro();

            RegexQuantifiersAndCharacterClasses();

            RegexAlternationConstructs();
        }

        private static void RegexIntro()
        {
            const string dataToParse = "ToMove.2 See.You High.5";

            //Match
            var pattern = new Regex(@"(\w+)\.(\d{1})");

            var didPatternMatch = pattern.IsMatch(dataToParse);

            var matches = pattern.Matches(dataToParse);
            var firstMatch = matches[0].Value;
            var secondMatch = matches[1].Value;

          
            var firstMatchGroups = matches[0].Groups;
          
            var overallGroup = firstMatchGroups[0];         
            var wordGroup = firstMatchGroups[1];
            var digitGroup = firstMatchGroups[2];

            // Split
            var parts = Regex.Split(dataToParse, @"\s|\.");

            // Replace
            var dataWithLemniscates = Regex.Replace(dataToParse, @"\.", " ∞ ");
        }

        private static void RegexQuantifiersAndCharacterClasses()
        {
            const string dataToParse0 = "A225 i7 x86 #116";
            /*
             . - wildcard, can substitute for almost any char */
            var pattern00 = new Regex(@".(\d{3})");

            // Will create what?
            var matches00 = pattern00.Matches(dataToParse0);


            const string dataToParse1 = " On the Turning Away ";
            /*
             \s - matches any whitespace character, similarly \n represents new line character */
            var pattern01 = new Regex(@"\s.{3}\s");

            // Will create what?
            var matches01 = pattern01.Matches(dataToParse1);


            const string dataToParse2 = "A225 1 % HeyYou! 50 $ J33$";
            /*
             \W -  is non-word character such as any char except [a-zA-Z_0-9]
             ? - is quantifier meaning that word char in \w? is expected to occur zero or once
             {2,4} - is quantifier meaning that decimal in \d{2,4} is expected to occur from 2 to 4 times
             \s{1,} - \s is whitespace character, {1,} is quantifier meaning that whitespace is expected to occur at least once */
            var pattern02 = new Regex(@"(\w?)(\d{2,4})(\s{1,})(\W*)");

            // Will create what?
            var matches02 = pattern02.Matches(dataToParse2);

            /*
             \D - is non-decimal character such as any char except [0-9]
             [ ] -  syntactic construct for character grouping
             ^ - is negation meaning that [^\D06-9] will match following decimal characters 1, 2, 3, 4 and 5 */
            var pattern03 = new Regex(@"([A]?)([^\D06-9]{2,4})(\s{1,})([^\$\w\d]*)");

            // Will create what?
            var matches03 = pattern03.Matches(dataToParse2);

            // Greedy vs. lazy matching (-> lazy matching adds '?' char at the end of the quantifier) 
            const string dataToParse3 = "123456789";

            // Will create what?
            var matches04 = Regex.Matches(dataToParse3, @"123\d+");

            // Will create what?
            var matches05 = Regex.Matches(dataToParse3, @"123\d+?");
        }

        private static void RegexAlternationConstructs()
        {
            const string dataToParse01 = "What a whacky whale";

            /*
             | -  "OR" - in (t|cky|le) matches any from the given chars */
            var pattern01 = new Regex(@"wha(t|cky|le)", RegexOptions.IgnoreCase);

            // Will create what?
            var matches01 = pattern01.Matches(dataToParse01);

            const string dataToParse02 = "Go4it Store'n'Go Go2 Gxy";

            /*
                Syntax: (?(Condition)true|false) - if condition is satisfied, 
                        pattern defined within true place is used
                $ - is one of the anchors, specifically meaning that the match
                    must occur at the end of the string in this case
             */
            var pattern02 = new Regex(@"(?(Go)Go\d\w{2}|\w{3}$)", RegexOptions.IgnoreCase);

            // Will create what?
            var matches02 = pattern02.Matches(dataToParse02);
        }

    }
}
