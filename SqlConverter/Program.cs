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
            string query = "SELECT DISTINCT \r\n                C.CONTENT_ID,\r\n                IFNULL(CCB.NAME,CB.DISPLAY_NAME) CONTENT_NAME, \r\n                C.CMS_CONTENT_ID\r\n            FROM DT_CONTENT_DBA_CONTENT_SERVICE_SPC_REL REL,\r\n                DT_CONTENT_DBA_CONTENT C,\r\n                DT_CONTENT_DBA_CONTENT_SPEC CS,\r\n                DT_PRODUCT_DBA_RESOURCES RES,\r\n                DT_CONTENT_DBA_CONTENT_BROADCAST_CHN_REL CB \r\n                LEFT JOIN DT_CONTENT_DBA_C_CONTENT_BROADCAST_CHN_REL CCB \r\n                 ON CB.CONTENT_BROADCAST_CHN_REL_ID = CCB.CONTENT_BROADCAST_CHN_REL_ID\r\n                 AND CCB.CULTURE_TYPE_CD = ?I_CULTURE_TYPE_CD \r\n                 AND ?I_DATE BETWEEN CCB.VALID_FROM AND CCB.VALID_THRU\r\n            WHERE C.CONTENT_SPEC_ID = CS.CONTENT_SPEC_ID\r\n                AND CB.CONTENT_ID = C.CONTENT_ID\r\n                AND CS.CONTENT_SPEC_CD = 'CHANNEL'\r\n                AND C.CONTENT_ID = REL.CONTENT_ID \r\n                AND CB.APPLICATION_ID =?I_APPLICATION_ID\r\n                AND IFNULL(CB.CLIENT_ID, ?I_CLIENT_ID ) = ?I_CLIENT_ID\r\n                AND (REL.SATELLITE_TYPE_CD = ?I_SATELLITE_TYPE_CD OR REL.SATELLITE_TYPE_CD IS NULL)  \r\n                AND ?I_DATE BETWEEN CB.VALID_FROM AND CB.VALID_THRU\r\n                AND ?I_DATE BETWEEN RES.VALID_FROM AND DATE_ADD(RES.VALID_THRU, INTERVAL 1 DAY)\r\n                AND RES.SERVICE_SPEC_ID = REL.SERVICE_SPEC_ID \r\n                 AND (NOT EXISTS\r\n                        (SELECT 1\r\n                        FROM DT_CONTENT_DBA_CONTENT_GEO_LOCATION_REL CGL\r\n                        WHERE CGL.CONTENT_BROADCAST_CHN_REL_ID = CB.CONTENT_BROADCAST_CHN_REL_ID\r\n                            AND CGL.LOGICAL_DELETE_KEY IS NULL)\r\n                    OR EXISTS\r\n                        (SELECT 1\r\n                        FROM DT_CONTENT_DBA_CONTENT_GEO_LOCATION_REL CGL\r\n                        WHERE CGL.CONTENT_BROADCAST_CHN_REL_ID = CB.CONTENT_BROADCAST_CHN_REL_ID\r\n                            AND CGL.GEO_LOCATION_ID = ?I_GEO_LOCATION_ID\r\n                            AND CGL.LOGICAL_DELETE_KEY IS NULL))  \r\n                AND C.LOGICAL_DELETE_KEY IS NULL\r\n                AND CS.LOGICAL_DELETE_KEY IS NULL\r\n                AND RES.LOGICAL_DELETE_KEY IS NULL\r\n                AND REL.LOGICAL_DELETE_KEY IS NULL\r\n                AND CB.LOGICAL_DELETE_KEY IS NULL";

            QueryParser queryParser = new QueryParser(query);

            //{

            //    ConverterHandler handlerADD = new ConverterAdd();
            //    ConverterHandler handlerCEIL = new ConverterCEIL();
            //    ConverterHandler handlerDATE = new ConverterDATE();
            //    ConverterHandler handlerDates = new ConverterDates();
            //    ConverterHandler handlerDays = new ConverterDays();
            //    ConverterHandler handlerIFNULL = new ConverterIFNULL();
            //    ConverterHandler handlerLENGTH = new ConverterLENGTH();
            //    ConverterHandler handlerNOW = new ConverterNOW();
            //    ConverterHandler handlerQUESTİON = new ConverterQuestion();
            //    ConverterHandler handlerSYSDATE = new ConverterSYSDATE();
            //    ConverterHandler handlerTIMESTAMP = new ConverterTIMESTAMP();
            //    ConverterHandler handlerTimes = new ConverterTimes();
            //    ConverterHandler handlerUSER = new ConverterUSER();
            //    ConverterHandler handlerDBA = new ConverterDBA();


            //    handlerADD.setNextConverterHandler(handlerCEIL);
            //    handlerCEIL.setNextConverterHandler(handlerDATE);
            //    handlerDATE.setNextConverterHandler(handlerDates);
            //    handlerDates.setNextConverterHandler(handlerDays);
            //    handlerDays.setNextConverterHandler(handlerIFNULL);
            //    handlerIFNULL.setNextConverterHandler(handlerLENGTH);
            //    handlerLENGTH.setNextConverterHandler(handlerNOW);
            //    handlerNOW.setNextConverterHandler(handlerQUESTİON);
            //    handlerQUESTİON.setNextConverterHandler(handlerSYSDATE);
            //    handlerSYSDATE.setNextConverterHandler(handlerTIMESTAMP);
            //    handlerTIMESTAMP.setNextConverterHandler(handlerTimes);
            //    handlerTimes.setNextConverterHandler(handlerUSER);
            //    handlerUSER.setNextConverterHandler(handlerDBA);


            //    handlerADD.Convert(queryParser);
            //}

            List<ConverterHandler> handlers = new List<ConverterHandler>
            {
                new ConverterAdd(),
                new ConverterCEIL(),
                new ConverterDATE(),
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


            Console.WriteLine(queryParser.query);
            




        

        }
    }
}