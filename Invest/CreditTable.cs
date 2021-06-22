using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest
{
    class CreditTable : CreditCalculation
    {
        private string agreementdate;
        private string calculatedate;

        //private double i;
        private int agday; //Agreement date(day)
        private int agmonth; //Agreement date (month)
        private int agyear; //Agreement date (year)

        private int clday; //Calculation date (day)
        private int clmonth;  //Calculation date (month)
        private int clyear;  //Calculation date (year)

        private double pmt_result; //PMT
        private double repayment_result;  //The interest of the current month has been repaid 
        private double amortization_result; //Debt repaid this month 
        private double debt_currentmonth_result; //The balance of the debt for the current month

        private string date; //Date of the current month 
        private string month;  //Current month 

        private int countstart; // Calculation date - Agreement date

        BindingList<CalculationResult> list = null; // Credit list 

        public string AgreementDate
        {
            get { return agreementdate; }
            set { agreementdate = value; }
        }

        public string CalculateDate
        {
            get { return calculatedate; }
            set { calculatedate = value; }
        }


        public double PaidDebt { get; set; } // Debt paid on the calculated date 
        public double LeftDebt { get; set; } // The balance of the debt on the calculated date 
        public double RestOfMonth { get; set; } // The rest of the months on the calculated date 


        public CreditTable()
        {

        }

        public CreditTable(string agdate, double x, double n, double r, string caldate) : base (x, n, r)
        {
            AgreementDate = agdate;
            CalculateDate = caldate;
        }

        //Agreement date, Calculation date. Calculation date - Agreement date
        public void CalculateOfDates()
        {
            int startIndex1 = 0;
            int length1 = 2;
            string agsubstring1 = AgreementDate.Substring(startIndex1, length1);
            string clsubstring1 = CalculateDate.Substring(startIndex1, length1);
            int startIndex2 = 3;
            int length2 = 2;
            string agsubstring2 = AgreementDate.Substring(startIndex2, length2);
            string clsubstring2 = CalculateDate.Substring(startIndex2, length2);
            int startIndex3 = 6;
            int length3 = 4;
            string agsubstring3 = AgreementDate.Substring(startIndex3, length3);
            string clsubstring3 = CalculateDate.Substring(startIndex3, length3);

            agday = Int32.Parse(agsubstring1);
            agmonth = Int32.Parse(agsubstring2);
            agyear = Int32.Parse(agsubstring3);
        
            clday = Int32.Parse(clsubstring1);
            clmonth = Int32.Parse(clsubstring2);
            clyear = Int32.Parse(clsubstring3);

            countstart = 12 * (clyear - agyear) + (clmonth - agmonth);

        }

        // Credit list creation function 
        public BindingList<CalculationResult> ShowList()
        {
            list = new BindingList<CalculationResult>();

            // Allow new parts to be added, but not removed once committed.        
            list.AllowNew = true;
            list.AllowRemove = false;
            // Raise ListChanged events when new parts are added.
            list.RaiseListChangedEvents = true;
            // Do not allow parts to be edited.
            list.AllowEdit = false;

            CalculateOfDates();

            //Display the start date of the investment period (month)
            for (int i = 0; i < N*12; i++)
            {
                if (i == 0)
                {
                    date = Convert.ToString(agday) + "." + Convert.ToString(agmonth) + "." + Convert.ToString(agyear);
                }
                else
                {
                    date = Convert.ToString(agday) + "." + Convert.ToString(agmonth + 1) + "." + Convert.ToString(agyear);
                    agmonth += 1;
                    if (agmonth == 12)
                    {
                        agmonth = 0;
                        agyear += 1;
                    }
                }
                month = Convert.ToString(i + 1) + " month";
                pmt_result = CalculationPMT();
                repayment_result = CalculationRepaymentOfInterests(); //Call the interest calculation function for the current month 
                amortization_result = CalculationAmort(); //Call the debt repayment calculation function of the current month 
                debt_currentmonth_result = CalculationDebtCurrMonth(); //Call the debt balance calculation function for the current month 

                if (i >= countstart)
                {
                    list.Add(new CalculationResult(date, month, pmt_result, repayment_result, amortization_result, debt_currentmonth_result));
                } 
            }
            CalculateTotalAmount();  //Call the total debt calculation function 
            CalculateLoanOverpayment();  //Call the overpayment calculation function 
            CalculatePaidDebt(); // Call the function of calculating the paid debt on the calculated date 
            CalculateLeftDebt();  //  Call the debt balance calculation function on the calculated date 
            CalculateRestOfMonth(); //  Call the function of calculating the balance of months on the calculated date 

            return list;
        }

        // The function of calculating the paid debt on the calculated date 
        public void CalculatePaidDebt()
        {
            PaidDebt = Math.Round(countstart * PMT, 2);
        }

        //  Debt balance calculation function on the calculated date 
        public void CalculateLeftDebt()
        {
            LeftDebt = Math.Round(TotalAmount - PaidDebt, 2);
        }

        //  The function of calculating the balance of months on the calculated date 
        public void CalculateRestOfMonth()
        {
            RestOfMonth = N * 12 - countstart;
        }

    }
}
