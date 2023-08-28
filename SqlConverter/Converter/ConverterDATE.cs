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
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                if (queryParser.queryList[i].Contains(" DATE"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" DATE", "TRUNC");
                }

            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}

