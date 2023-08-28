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
            foreach (string s in queryParser.queryList)
            {
                //Console.WriteLine(s);
                if (s.Contains(" ADDDATE"))
                {
                    //Console.WriteLine("evet");
                }
            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
