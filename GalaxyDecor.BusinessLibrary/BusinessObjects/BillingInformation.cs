using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyDecor.BusinessLibrary.BusinessObjects
{
    public class BillingInformation
    {
        public BillingInformation()
        {
            prpMembersInformation = new MembersInformation();
            itemInformation = new Items();
        }

        private int _BillNo;

        public int BillNo
        {
            get { return _BillNo; }
            set { _BillNo = value; }
        }

        public MembersInformation prpMembersInformation { get; set; }
        public Items itemInformation { get; set; }

        private double _Total;
        
        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private double _GrandTotal;

        public double GrandTotal
        {
            get { return _GrandTotal; }
            set { _GrandTotal = value; }
        }

        private double _PVPoints;

        public double PVPoints
        {
            get { return _PVPoints; }
            set { _PVPoints = value; }
        }

        private DateTime _BIllIssueDate;

        public DateTime BillIssueDate
        {
            get { return _BIllIssueDate; }
            set { _BIllIssueDate = value; }
        }

        private string _YearMonth;

        public string YearMonth
        {
            get { return _YearMonth; }
            set { _YearMonth = value; }
        }
    }
}
