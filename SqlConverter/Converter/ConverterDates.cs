using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    public class ConverterDates : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {

                if (queryParser.queryList[i].Contains(" DATE("))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" DATE(", " TRUNC(");
                }

                if (queryParser.queryList[i].Contains(" CURDATE()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CURDATE()", " TRUNC(SYSDATE)"); // oldu
                }

                if (queryParser.queryList[i].Contains(" CURRENT_DATE") && !queryParser.queryList[i].Contains("()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CURRENT_DATE", " TRUNC(SYSDATE)"); // oldu
                }

                if (queryParser.queryList[i].Contains(" CURRENT_DATE()"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" CURRENT_DATE()", " TRUNC(SYSDATE)"); // oldu
                }

                if (queryParser.queryList[i].Contains(" DATE_FORMAT"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" DATE_FORMAT", " TO_CHAR"); // oldu
                }
                
                if (queryParser.queryList[i].Contains(" DATE_SUB")) // oldu
                {
                    string date, value, ınterval, addunit;

                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");

                    temp = temp[1].Split(",");
                    date = temp[0];

                    temp = temp[1].Split(" ");
                    ınterval = temp[1];
                    value = temp[2];

                    temp = temp[3].Split(")");
                    addunit = temp[0];

                    //Console.WriteLine("date:" + date.ToString());
                    //Console.WriteLine("ınterval:" + ınterval.ToString());
                    //Console.WriteLine("value:" + value.ToString());
                    //Console.WriteLine("addunıt:" + addunit.ToString());


                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" DATE_SUB(", " ");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(",", " -");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" "+value.ToString(), " '" + value.ToString() + "'");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(addunit.ToString() + ")",addunit.ToString() );

                }// oldu

                if (queryParser.queryList[i].Contains(" SUBDATE"))
                {
                    string date, ınterval, value, unıt;                  

                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");

                    temp = temp[1].Split(",");
                    date = temp[0];

                    temp = temp[1].Split(" ");
                    ınterval = temp[1];
                    value = temp[2];

                    temp = temp[3].Split(")");
                    unıt = temp[0];

                    Console.WriteLine("date:" + date.ToString());
                    Console.WriteLine("ınterval:" + ınterval.ToString());
                    Console.WriteLine("value:" + value.ToString());
                    Console.WriteLine("unıt:" + unıt.ToString());

                    queryParser.queryList[i] = queryParser.queryList[i] = queryParser.queryList[i].Replace(" SUBDATE(", " ");
                    queryParser.queryList[i] = queryParser.queryList[i] = queryParser.queryList[i].Replace(",", " -");
                    queryParser.queryList[i] = queryParser.queryList[i] = queryParser.queryList[i].Replace(" " + value.ToString(), "'" + value.ToString() + "'");
                    queryParser.queryList[i] = queryParser.queryList[i] = queryParser.queryList[i].Replace(unıt.ToString() + ")",unıt.ToString());





                } // oldu


                if (queryParser.queryList[i].Contains(" DATE_ADD"))
                {
                    string date, ınterval, value, addunıt;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");

                    temp = temp[1].ToString().Split(",");

                    date = temp[0];
        
                    temp = temp[1].ToString().Split(" ");
  
                    ınterval = temp[1];
                    value = temp[2];

                    

                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" "+value.ToString()," '"+ value.ToString()+"'");

                }






            }

            _nextConverterHandler.Convert(queryParser);
        }
    }
}
