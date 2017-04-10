using System.Text.RegularExpressions;

namespace RegularExpressions
{
    public static class Solution
    {
        public static void Tasks()
        {
            const string dataToParse01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                                         "Ut lobortis dui in erat commodo, eu ornare orci semper. ";
            /* TODO
             Napište regulární výraz, který z řetězce dataToParse03 získá všechny slova 
             obsahující řetězec "lo" (výraz vytvořte jako case-insensitive)            
             */

            var wordsWithLoPattern = new Regex(@"(\w*lo\w*)", RegexOptions.IgnoreCase);

            var wordsContainingLo = wordsWithLoPattern.Matches(dataToParse01);


            //======================================================================================================


            const string dataToParse02 = "Throughout March 1973, the band negotiated a new contract " +
                                         "with Columbia Records, who gave them a reported advance of " +
                                         "$1,000,000 which is worth approximately $5,000,000 today since $1 ...";
            /* TODO
             Napište regulární výraz, který z řetězce dataToParse02 získá všechny částky v $ 
             (formát částky zachovejte $X,XXX,XXX...) 
             Tip: jak již bylo uvedeno, znak $ je rezervovaný, 
             proto je třeba před něj uvést zpětné lomítko: '\$'
             */

            var extractSumsPattern = new Regex(@"(\$\d+[,\d{3}]*)");

            var extractedSums = extractSumsPattern.Matches(dataToParse02);


            //======================================================================================================


            const string dataToParse03 = "<h1>The headline text</h1> <p>...</p>";
            /* TODO
             Napište regulární výraz, který z řetězce dataToParse04 získá hodnotu tagů h1 a p, 
             tedy řetězce "The headline text" a "..."
             */

            var tagContentPattern = new Regex(@"<\w+>(.*?)</\w+>");

            var tagContent = tagContentPattern.Matches(dataToParse03);
            if (tagContent.Count == 2)
            {
                var contentOfH1Tag = tagContent[0].Groups[1];
                var contentOfPTag = tagContent[1].Groups[1];
            }          
            
            
            //======================================================================================================


            const string dataToParse04 = "178 255 12879 1 5429786 0 75893 43 88 116";
            /* TODO
             Napište regulární výraz, který z řetězce dataToParse01 získá pouze sudá čísla
             */

            var evenNumbersPattern = new Regex(@"(\d*[02468])(\s|$)");

            var evenNumbers = evenNumbersPattern.Matches(dataToParse04); 
        }
    }
}
