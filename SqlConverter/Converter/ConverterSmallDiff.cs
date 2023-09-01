using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter.Converter
{
    internal class ConverterSmallDiff : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            for (int i = 0; i < queryParser.queryList.Count; i++)
            {
                if (queryParser.queryList[i].Contains(" LCASE"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" LCASE", " LOWER");
                }

                if (queryParser.queryList[i].Contains(" LEFT"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" LEFT", " SUBSTR");

                    string fırstunıt;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");

                    temp = temp[1].Split(",");

                    fırstunıt = temp[0];

                    queryParser.queryList[i] = queryParser.queryList[i].Replace(fırstunıt, fırstunıt + ", 1");

                }

                if (queryParser.queryList[i].Contains(" LOCATE"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" LOCATE", " INSTR");
                }

                if (queryParser.queryList[i].Contains(" POSITION"))
                {
                    //queryParser.queryList[i] = queryParser.queryList[i].Replace(" POSITION(", " INSTR");

                    //string subString, lastString;
                    //string[] temp;


                    //temp = queryParser.queryList[i].Split("(");
                    //temp = temp[1].Split(")");
                    ////temp = temp[0].Split(" ");

                    //foreach (string s in temp)
                    //{
                    //    Console.WriteLine(s);
                    //}
                   
                    //subString = temp[0];
                    //lastString = temp[2];

                    

                    //queryParser.queryList[i] = queryParser.queryList[i].Replace(subString + " IN", lastString);
                   


                }

                //repeat
                //RIGHT

                if (queryParser.queryList[i].Contains(" SPACE"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" SPACE(", " RPAD(' ', ");
                }
                
                if (queryParser.queryList[i].Contains(" SUBSTRING"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" SUBSTRING", " SUBSTR");
                }

                if (queryParser.queryList[i].Contains(" UCASE"))
                {
                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" UCASE", " UPPER");
                }

                if (queryParser.queryList[i].Contains(" COT("))
                {
                    string number;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");

                    temp = temp[1].Split(")");
                    number = temp[0];

                    queryParser.queryList[i] = queryParser.queryList[i].Replace("COT("+ number + ")", "COS(" + number + ")/SIN(" + number + ")");

                }

                if (queryParser.queryList[i].Contains(" DEGREES("))
                {
                    string number;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");

                    temp = temp[1].Split(")");
                    number = temp[0];

                    queryParser.queryList[i] = queryParser.queryList[i].Replace(" DEGREES"," ");
                    queryParser.queryList[i] = queryParser.queryList[i].Replace("(" + number + ")", "(" + number + ")" + " * 180/3.1415926535");

                }

                //DIV

                if (queryParser.queryList[i].Contains("LOG10"))
                {
                    string number;
                    string[] temp;

                    temp = queryParser.queryList[i].Split("(");
                    temp = temp[1].Split(")");

                    number = temp[0];

                    queryParser.queryList[i] = queryParser.queryList[i].Replace("LOG10(" + number + ")", "LOG(10," + number + ")");
                }


            }
            _nextConverterHandler.Convert(queryParser);
        }
    }
}
