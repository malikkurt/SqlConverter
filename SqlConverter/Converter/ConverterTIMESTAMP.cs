using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterTIMESTAMP : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("TIMESTAMP KONTROL");

            if (queryParser.query.Contains("CURRENT_TIMESTAMP()"))
            {
                string source = queryParser.query;
                // burada CURRENT_TIMESTAMP ama aynı olduğu için eklemedim
                source = source.Replace("CURRENT_TIMESTAMP()", "CURRENT_TIMESTAMP");

                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
