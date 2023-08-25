using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterNOW : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("NOW() KONTROL");

            if (queryParser.query.Contains("NOW()"))
            {
                string source = queryParser.query;

                source = source.Replace("NOW()", "SYSTIMESTAMP");

                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);

        }
    }
}
