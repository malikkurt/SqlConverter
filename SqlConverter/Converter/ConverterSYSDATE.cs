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
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                //if (queryParser.queryList[i].Contains("SYSDATE()"))
                //{
                //    queryParser.queryList[i] = queryParser.queryList[i].Replace("SYSDATE()", "SYSDATE");
                //}

            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
