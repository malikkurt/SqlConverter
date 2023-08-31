using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
                    string date,days, value, addunit, ınterval;
                    string[] temp;
                    
                    temp = queryParser.queryList[i].Split("(");
                   
                    temp = temp[1].Split(",");
                    date = temp[0];

                    temp = temp[1].Split(" ");
                    ınterval = temp[1];
                    value = temp[2];

                    temp = temp[3].Split(")");
                    addunit = temp[0];

                    Console.WriteLine("date:" + date.ToString());
                    Console.WriteLine("deneme:" + ınterval.ToString());
                    Console.WriteLine("value:" + value.ToString());
                    Console.WriteLine("addunıt:" + addunit.ToString());
                    
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(",", " +");

                    if (value.ToString().Contains("'"))
                    {
                        queryParser.queryList[i] = queryParser.queryList[i].Replace(" ADDDATE(", " ");
                        queryParser.queryList[i] = queryParser.queryList[i].Replace(ınterval.ToString(), "NUMTODS" + ınterval.ToString());
                        queryParser.queryList[i] = queryParser.queryList[i].Replace(value.ToString(), "(" + value.ToString());
                        queryParser.queryList[i] = queryParser.queryList[i].Replace(addunit.ToString(),addunit.ToString());


                        //queryParser.queryList[i] = queryParser.queryList[i].Replace(value.ToString(),value.ToString());
                    }
                    else
                    {
                        queryParser.queryList[i] = queryParser.queryList[i].Replace(" ADDDATE(", " ");
                        queryParser.queryList[i] = queryParser.queryList[i].Replace(value.ToString(),"'"+value.ToString()+"'");
                        queryParser.queryList[i] = queryParser.queryList[i].Replace(addunit.ToString() + ")", addunit.ToString());

                    }
                    
                 
                    




        }

            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
