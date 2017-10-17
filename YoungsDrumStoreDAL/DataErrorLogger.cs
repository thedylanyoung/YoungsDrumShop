using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YoungsDrumStoreDAL
{
    public class DataErrorLogger
    {
        public static void ErrorLogger(string levelType, DateTime timeStamp,string errorMessage)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\Onshore\\Desktop\\YoungsDrumStore\\YoungsDrumStore\\bin\\DATAERRORLOG.txt", true))
            {
                writer.WriteLine("Level: " + levelType + "   Time: " + timeStamp + "   Message: " + errorMessage);
            }
        }
    }
}
