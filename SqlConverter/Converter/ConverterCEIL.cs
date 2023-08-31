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
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                if (queryParser.queryList[i].Contains("CEILING"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("CEILING", "CEIL");// okey
                }

                //if (queryParser.queryList[i].Contains("CEIL"))
                //{
                //    queryParser.queryList[i] = queryParser.queryList[i].Replace("CEIL", "CEIL");
                //}
            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
