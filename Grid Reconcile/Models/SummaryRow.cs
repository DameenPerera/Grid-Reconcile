using System;
using System.Collections.Generic;
using System.Text;

namespace Grid_Reconcile.Models
{
    public class SummaryRow
    {
        public int RowNumber { get; set; }
        public string BlockType { get; set; } = "";
        public string TxnNo { get; set; } = "";
        public string RefNo { get; set; } = "";
        public string AccName { get; set; } = "";
        public decimal AccAmount { get; set; }
        public string Narration { get; set; } = "";
        public DateTime? BankRealizedDate { get; set; }
        public string UserName { get; set; } = "";
    }
}
