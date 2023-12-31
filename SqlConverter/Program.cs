﻿using SqlConverter;
using SqlConverter.Converter;
using System.Text;

namespace HelloWorld
{
    class Program
    {

        static void Main(string[] args)
        {
         
            while(true)
            {
                StringBuilder allQuery = new StringBuilder();

                Console.WriteLine("Query Input:");

                while(true)
                {
                    string lıne = Console.ReadLine();

                    if(lıne == "0")
                    {
                        break;
                    }

                    allQuery.AppendLine(lıne);

                }

                string query = allQuery.ToString();


                QueryParser queryParser = new QueryParser(query);

                List<ConverterHandler> handlers = new List<ConverterHandler>
                {
                    new ConverterDateFunctions(),
                    new ConverterSmallDiff(),
                    new ConverterQuestion(),
                    new ConverterTimes(),
                    new ConverterAdvancedFunctions(),
                    new ConverterSQLReferences(),
                    new ConverterDBA()
                };

                
                for ( int i = 0; i < handlers.Count - 1; i++)
                {
                    handlers[i].setNextConverterHandler(handlers[i + 1]);
                }
                handlers[0].Convert(queryParser);


                
                foreach(string s in queryParser.queryList)
                {
                    string temizMetin = s.Replace("\r\n", "");
                    Console.WriteLine(temizMetin);


                }
            }
         
        }
    }
}