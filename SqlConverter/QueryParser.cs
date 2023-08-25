using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConverter
{
    public class QueryParser
    {

        public string query;
        StringBuilder sb = new StringBuilder();


        public QueryParser(string _query)
        {
            //string[] strings = _query.Split("  ");
            //foreach (string s in strings)
            //{
            //    if(s == "")
            //    {

            //    }
            //    else
            //    {
            //        sb.Append(s);
            //    }
            //}
            
            //Console.WriteLine(sb);
            
            //this.query = sb.ToString();

            query = _query;

        }
    }
}
