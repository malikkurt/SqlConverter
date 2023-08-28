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
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                if (queryParser.queryList[i].Contains(" CURDATE()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" IFNULL", " TRUNC(SYSDATE)");
                }

                if (queryParser.queryList[i].Contains(" CURRENT_DATE"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CURRENT_DATE", " TRUNC(SYSDATE)");
                }

                if (queryParser.queryList[i].Contains(" CURRENT_DATE()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CURRENT_DATE()", " TRUNC(SYSDATE)");
                }
            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
