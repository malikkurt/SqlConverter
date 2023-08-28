using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterLENGTH : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                if (queryParser.queryList[i].Contains(" CHAR_LENGTH"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CHAR_LENGTH", "LENGTH");
                }

                if (queryParser.queryList[i].Contains(" CHARACTER_LENGTH"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CHARACTER_LENGTH", "LENGTH");
                }
            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
