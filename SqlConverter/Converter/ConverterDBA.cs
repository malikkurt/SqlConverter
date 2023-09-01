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

            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                if (queryParser.queryList[i].Contains("_DBA_"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("_DBA_", "_DBA.");
                }

                
            }
            //_nextConverterHandler.Convert(queryParser);
        }
    }
}
