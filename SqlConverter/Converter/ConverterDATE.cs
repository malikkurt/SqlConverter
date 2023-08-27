using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterDATE : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            Console.WriteLine("Date KONTROL");

            if (queryParser.query.Contains(" DATE_ADD") || queryParser.query.Contains(" DATE_FORMAT") || queryParser.query.Contains(" DATE_SUB") || queryParser.query.Contains(" DATE") || queryParser.query.Contains(" DATEDIFF"))
            {
                string source = queryParser.query;

                source = source.Replace(" DATE_ADD", "");// burada () işaretlerini de silmem gerekiyor olabilir bakarsın 
                source = source.Replace(" DATE_FORMAT", " TO_CHAR");
                source = source.Replace(" DATE_SUB", "");// burada () işaretlerini de silmem gerekiyor olabilir bakarsın 
                source = source.Replace(" DATE", " TRUNC");
                source = source.Replace(" DATEDIFF", " --sorun--"); // sorunlu bura


                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
