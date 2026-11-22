namespace Grid_Reconcile.Models
{
    public class InstructionRow
    {
        public string SheetName { get; set; } = "";
        public int RowNumber { get; set; }
        public string EmailDate { get; set; } = "";
        public string RefNo { get; set; } = "";          // Facility / BSP No  (or NARRATION for GL)
        public string CustomerOrGlNarration { get; set; } = ""; // Customer Name or GL Narration
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = "";
        public DateTime? BankRealizedDate { get; set; }
        public string DepositedBank { get; set; } = "";
    }
}