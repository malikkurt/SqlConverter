using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterDBA : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("DBA KONTROL");

            if (queryParser.query.Contains("DBA"))
            {
                string source = queryParser.query;

                source = source.Replace("_DBA_", "_DBA.");

                queryParser.query = source;

            }
            //_nextConverterHandler.Convert(queryParser);
        }
    }
}
