using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterAdd : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {

            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                if (queryParser.queryList[i].Contains(" ADDDATE"))
                {
                    string [] sourceList = queryParser.queryList[i].Split('(',',',')');



                    foreach(string s in sourceList)
                    {
                        Console.WriteLine(s);
                    }


                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" ADDDATE", " ");
                }
                

            }


            _nextConverterHandler.Convert(queryParser);
        }
    }
}
