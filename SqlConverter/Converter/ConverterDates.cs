using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterDates : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("Dates KONTROL");

            if (queryParser.query.Contains("CURDATE()") || queryParser.query.Contains("CURRENT_DATE") || queryParser.query.Contains("CURRENT_DATE()"))
            {
                string source = queryParser.query;

                source = source.Replace("CURDATE()", "TRUNC(SYSDATE)");
                source = source.Replace("CURRENT_DATE", "TRUNC(SYSDATE)");
                source = source.Replace("CURRENT_DATE()", "TRUNC(SYSDATE)");
                

                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
