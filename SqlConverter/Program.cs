using SqlConverter;
using SqlConverter.Converter;
using System;

using System.Text;


namespace HelloWorld
{
    class Program
    {


        static void Main(string[] args)
        {
         
            while(true)
            {
                Console.WriteLine("Lütfen bir SQL sorgusu girin:");
                string query = Console.ReadLine();


                QueryParser queryParser = new QueryParser(query);

                List<ConverterHandler> handlers = new List<ConverterHandler>
                {
                    new ConverterAdd(),
                    new ConverterCEIL(),
                    new ConverterDates(),
                    new ConverterDays(),
                    new ConverterIFNULL(),
                    new ConverterLENGTH(),
                    new ConverterNOW(),
                    new ConverterQuestion(),
                    new ConverterSYSDATE(),
                    new ConverterTIMESTAMP(),
                    new ConverterTimes(),
                    new ConverterUSER(),
                    new ConverterDBA()
                };

                // ConverterHandler nesnelerini zincirleme bağla
                for ( int i = 0; i < handlers.Count - 1; i++)
                {
                    handlers[i].setNextConverterHandler(handlers[i + 1]);
                }
                handlers[0].Convert(queryParser);


                foreach(string s in queryParser.queryList)
                {
                    Console.WriteLine(s);
                }

                }

            



        

        }
    }
}