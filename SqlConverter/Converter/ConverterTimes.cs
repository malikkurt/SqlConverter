using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    internal class ConverterTimes : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("Times KONTROL");

            if (queryParser.query.Contains("CURTIME()") || queryParser.query.Contains("CURRENT_TIME") || queryParser.query.Contains("CURRENT_TIME()"))
            {
                string source = queryParser.query;

                source = source.Replace("CURTIME()", "SYSTIMESTAMP");
                source = source.Replace("CURRENT_TIME", "SYSTIMESTAMP");
                source = source.Replace("CURRENT_TIME()", "SYSTIMESTAMP");


                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
