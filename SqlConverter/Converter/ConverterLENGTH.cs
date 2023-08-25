using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterLENGTH : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("LENGTH - CHAR KONTROL");

            if (queryParser.query.Contains("CHAR_LENGTH") || queryParser.query.Contains("CHARACTER_LENGTH"))
            {
                string source = queryParser.query;

                source = source.Replace("CHAR_LENGTH", "LENGTH");
                source = source.Replace("CHARACTER_LENGTH", "LENGTH");

                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
