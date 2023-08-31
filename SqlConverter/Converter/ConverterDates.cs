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

                if (queryParser.queryList[i].Contains(" DATE("))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" DATE(", " TRUNC(");
                }

                if (queryParser.queryList[i].Contains(" CURDATE()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CURDATE()", " TRUNC(SYSDATE)"); // oldu
                }

                if (queryParser.queryList[i].Contains(" CURRENT_DATE") && !queryParser.queryList[i].Contains("()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CURRENT_DATE", " TRUNC(SYSDATE)"); // oldu
                }

                if (queryParser.queryList[i].Contains(" CURRENT_DATE()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CURRENT_DATE()", " TRUNC(SYSDATE)"); // oldu
                }

                if (queryParser.queryList[i].Contains(" DATE_FORMAT"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" DATE_FORMAT", " TO_CHAR"); // oldu
                }
                
                if (queryParser.queryList[i].Contains(" DATE_SUB"))
                {
                    






                }

               

                


            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
