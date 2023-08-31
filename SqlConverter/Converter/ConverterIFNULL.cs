using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter
{
    public class ConverterIFNULL : ConverterHandler
    {

        public override void Convert(QueryParser queryParser)
        {
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                if (queryParser.queryList[i].Contains("IFNULL"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("IFNULL", "NVL"); // oldu
                }

            }
            

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
