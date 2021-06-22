using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest
{
    class CreditCalculation : ICalculation
    {
        private double x;
        private double n;
        private double r;

        private double i;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double N
        {
            get { return n; }
            set { n = value; }
        }

        public double R
        {
            get { return r; }
            set { r = value; }
        }


        public double PMT { get; set; }
        public double Repayment { get; set; }
        public double Amortization { get; set; }
        public double Debt_currentmonth { get; set; }

        public double TotalAmount { get; set; }
        public double LoanOverpayment { get; set; }

        public CreditCalculation()
        {

        }
        public CreditCalculation(double x, double n, double r)
        {
            X = x;
            N = n;
            R = r;
            Debt_currentmonth = x;
        }

        //  Monthly payment calculation function
        public double CalculationPMT()
        {
            i = R / 100 / 12;

            PMT = (X * i * Math.Pow((1 + i), N * 12)) / (Math.Pow((1 + i), N * 12) - 1);

            return Math.Round(PMT, 2);
        }

        //  The function of calculating the repayment of interest for the current month
        public double CalculationRepaymentOfInterests()
        {
            Repayment = Debt_currentmonth * i;
            return Math.Round(Repayment, 2);
        }

        //  Debt repayment calculation function for the current month 
        public double CalculationAmort()
        {
            Amortization = PMT - Repayment;
            return Math.Round(Amortization, 2);
        }

        //  Debt balance calculation function for the current month 
        public double CalculationDebtCurrMonth()
        {
            Debt_currentmonth -= Amortization;
            return Math.Round(Debt_currentmonth, 2);
        }

        //  The function of calculating the total debt 
        public void CalculateTotalAmount()
        {
            TotalAmount = Math.Round(X + PMT * N * 12, 2);
        }

        //  The function of calculating the total overpayment 
        public void CalculateLoanOverpayment()
        {
            LoanOverpayment = Math.Round(PMT * N * 12 - X, 2);
        }
    }
}
