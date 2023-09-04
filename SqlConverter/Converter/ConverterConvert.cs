using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterConvert : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                //if (queryParser.queryList[i].Contains(" CONVERT"))
                //{
                //    string value, type;
                //    string[] temp;

                //    temp = queryParser.queryList[i].Split("(");

                //    temp = temp[1].ToString().Split(",");

                //    value = temp[0];

                //    foreach (string s in temp)
                //    {
                //        Console.WriteLine(s);
                //    }

                //    temp = temp[1].ToString().Split(" "); // BUG

                //    temp = temp[1].ToString().Split(")");

                //    type = temp[0];

                //    //Console.WriteLine("value: " + value);
                //    //Console.WriteLine("type: " + type);


                //    foreach (string s in temp)
                //    {
                //        Console.WriteLine(s);
                //    }

                //    if (queryParser.queryList[i].Contains("USING"))
                //    {
                //        queryParser.queryList[i] = queryParser.queryList[i].Replace(", ", " USING ");
                //    }
                //    else
                //    {
                //        queryParser.queryList[i] = queryParser.queryList[i].Replace(" CONVERT", " CAST");
                //        queryParser.queryList[i] = queryParser.queryList[i].Replace(",", " AS ");

                //    }

                    


               // }

            }


            _nextConverterHandler.Convert(queryParser);
        }

    }
}
