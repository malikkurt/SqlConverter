﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter
{
    public class ConverterQuestion : ConverterHandler
    {
        public override void Convert(QueryParser queryParser)
        {
            
            Console.WriteLine("Question KONTROL");

            if (queryParser.query.Contains("?"))
            {
                string source = queryParser.query;

                source = source.Replace("?", ":");

                queryParser.query = source;

            }
            _nextConverterHandler.Convert(queryParser);






        }

    }
}
