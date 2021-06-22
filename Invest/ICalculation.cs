using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest
{
    interface ICalculation
    {
        double X { get; set; }
        double N { get; set; }
        double R { get; set; }

        double PMT { get; set; }
        double Repayment { get; set; }
        double Amortization { get; set; }
        double Debt_currentmonth { get; set; }

        double TotalAmount { get; set; }
        double LoanOverpayment { get; set; }

        double CalculationPMT();
        double CalculationRepaymentOfInterests();
        double CalculationAmort();
        double CalculationDebtCurrMonth();

        void CalculateTotalAmount();
        void CalculateLoanOverpayment();
    }
}
