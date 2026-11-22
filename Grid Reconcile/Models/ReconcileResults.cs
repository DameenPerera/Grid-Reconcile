using System;
using System.Collections.Generic;
using System.Text;

namespace Grid_Reconcile.Models
{
    public class ReconcileResults
    {
        //Instruction

        public string SheetName { get; set; } = "";
        public int RowNumber { get; set; }
        public string EmailDate { get; set; } = "";
        public string RefNo { get; set; } = "";          // Facility / BSP No  (or NARRATION for GL)
        public string CustomerOrGlNarration { get; set; } = ""; // Customer Name or GL Narration
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = "";
        public DateTime? BankRealizedDate { get; set; }
        public string DepositedBank { get; set; } = "";

        //Summery

        public int SummeryRowNumber { get; set; }
        public string EnteredBlockType { get; set; } = "";
        public string EnteredTxnNo { get; set; } = "";
        public string EnteredRefNo { get; set; } = "";
        public string EnteredAccName { get; set; } = "";
        public decimal EnteredAccAmount { get; set; }
        public string EnteredNarration { get; set; } = "";
        public DateTime? EnteredBankRealizedDate { get; set; }
        public string EnteredUserName { get; set; } = "";

        //For Corrections
        public string Error { get; set; } = "";
    }
}
