using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterDays : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("Days KONTROL");

            if (queryParser.query.Contains("IFNULL"))
            {
                string source = queryParser.query;

                //source = source.Replace("IFNULL", "nvl");

                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
