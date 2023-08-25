using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterUSER : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("USER KONTROL");

            if (queryParser.query.Contains("CURRENT_USER") || queryParser.query.Contains("CURRENT_USER()"))
            {
                string source = queryParser.query;

                source = source.Replace("CURRENT_USER", "USER");
                source = source.Replace("CURRENT_USER()", "USER");

                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
