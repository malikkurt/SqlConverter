using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterCEIL : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("CEILING KONTROL");

            if (queryParser.query.Contains("CEILING"))
            {
                string source = queryParser.query;
                // burada ceıl de var ama aynı olduğu için koymadım
                source = source.Replace(" CEILING", " CEIL");

                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
