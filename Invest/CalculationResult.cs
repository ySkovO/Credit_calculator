using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest
{
    class CalculationResult
    {
        private string data;
        private string month;
        private double pmt;
        private double repayment;
        private double amortization;
        private double debt_currentmonth;


        public string Data { get; set; }
        public string Month { get; set; }
        public double Monthly_payment { get; set; }
        public double Interest_repayment  { get; set; }
        public double Amortization { get; set; }
        public double Debt { get; set; }
        

        public CalculationResult()
        {

        }

        public CalculationResult(string agdata, string month, double pmt, double repayment, double amort, double debt)
        {
            Data = agdata;
            Month = month;
            Monthly_payment = pmt;
            Interest_repayment = repayment;
            Amortization = amort;
            Debt = debt;
        }
    }
}
