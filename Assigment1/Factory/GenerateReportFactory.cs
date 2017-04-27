using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment1.Factory
{
   public class GenerateReportFactory
    {
       public virtual void  GenerateReports(int method, Activity activity)
       {
           IGenerateRaports raport = null;

           switch (method)
           {
               case 1:
                   raport = new ActivityFile();
                   raport.generateReports(activity);
                   break;
               case 2:
                   raport = new EmployeeFile();
                   raport.generateReports(activity);
                   break;
           }

          
       }
    }
}
