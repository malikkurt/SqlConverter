using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterUSER : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                //if (queryParser.queryList[i].Contains("CURRENT_USER"))
                //{
                //    queryParser.queryList[i] = queryParser.queryList[i].Replace("CURRENT_USER", "USER");
                //}

                //if (queryParser.queryList[i].Contains("CURRENT_USER()"))
                //{
                //    queryParser.queryList[i] = queryParser.queryList[i].Replace("CURRENT_USER()", "USER");
                //}
            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
