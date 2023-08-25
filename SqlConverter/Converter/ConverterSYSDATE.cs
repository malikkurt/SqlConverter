using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterSYSDATE : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("SYSDATE() KONTROL");

            if (queryParser.query.Contains("SYSDATE()"))
            {
                string source = queryParser.query;

                source = source.Replace("SYSDATE()", "SYSDATE");

                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
