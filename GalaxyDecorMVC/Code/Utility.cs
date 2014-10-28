using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalaxyDecorMVC.Code
{
    public static class Utility
    {
        /// <summary>
        /// This function does the task of forming the URL to refer js files.
        /// </summary>
        /// <param name="realtivePath">string path</param>
        /// <returns>Well formed path</returns>
        public static string FormAbsoluteURI(string realtivePath, string sharedAccessSignature)
        {
            return realtivePath.Replace("scripts", "/Scripts");
        }

//        public static struct TemplateForBill
//        {
//            public static const string BillTemplate = 
//                @"<Bill>
//                    <BillNo>{0}</BillNo>
//                    <MemberShipNo>{1}</MemberShipNo>
//                    
//                    <BillIssueDate>{2}</BillIssueDate>
//                </Bill>";
//        }
    }
}