using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    internal class ConverterConcat : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                if (queryParser.queryList[i].Contains(" CONCAT"))
                {
                    string last;
                    string[] expressıons,temp;

                    temp = queryParser.queryList[i].Split("(");

                    temp = temp[1].Split(")");
                    last = temp[1];
                    //temp = temp[0].Split(",");

                    Console.WriteLine(last);

                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CONCAT(", " ");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(")" + last.ToString(), last.ToString());
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(",", " ||");



                    


                }

            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
