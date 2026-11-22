using Grid_Reconcile.Models;
using OfficeOpenXml;
using System.Globalization;

namespace Grid_Reconcile.Services
{
    public class InstructionReader
    {
        public static List<InstructionRow> ReadInstructions(string filePath)
        {
            var rows = new List<InstructionRow>();

            using var package = new ExcelPackage(new FileInfo(filePath));

            foreach (var ws in package.Workbook.Worksheets)
            {
                if (ws.Dimension == null) continue; // Skip empty worksheets
                int lastRow = ws.Dimension.Rows;
                int lastCol = ws.Dimension.Columns;
                if (lastRow < 2) continue;  // header only / empty

                for (int row = 1; row <= lastRow; row++) //there is multiple header rows, so we will read all rows and let the consumer decide which ones to use
                {
                    // Read cells as text
                    string c1 = ws.Cells[row, 1].Text?.Trim() ?? "";
                    string c2 = ws.Cells[row, 2].Text?.Trim() ?? "";
                    string c3 = ws.Cells[row, 3].Text?.Trim() ?? "";
                    string c4 = ws.Cells[row, 4].Text?.Trim() ?? "";
                    string c5 = ws.Cells[row, 5].Text?.Trim() ?? "";
                    string c6 = ws.Cells[row, 6].Text?.Trim() ?? "";
                    string c7 = ws.Cells[row, 7].Text?.Trim() ?? "";

                    if (c1.Equals("Email Date", StringComparison.OrdinalIgnoreCase)) //skip header rows
                        continue;

                    // Skip fully blank rows (e.g. separator rows between blocks) 
                    if (string.IsNullOrWhiteSpace(c1) &&
                        string.IsNullOrWhiteSpace(c2) &&
                        string.IsNullOrWhiteSpace(c3) &&
                        string.IsNullOrWhiteSpace(c4))
                        continue;

                    // Build the row based on InstructionRow Layout
                    InstructionRow instr = new InstructionRow
                    {
                        SheetName = ws.Name,
                        RowNumber = row,
                        EmailDate = c1,
                        RefNo = c2,
                        CustomerOrGlNarration = c3,
                        Amount = ParseDecimal(c4),
                        PaymentMethod = c5,
                        BankRealizedDate = ParseDate(c6),
                        DepositedBank = c7
                    };
                    rows.Add(instr);
                }
            }

            return rows;
        }

        private static decimal ParseDecimal(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0m;
            s = s.Replace(",", "").Trim();
            return decimal.TryParse(s, NumberStyles.Any,
                                    CultureInfo.InvariantCulture, out var v) ? v : 0m;
        }

        private static DateTime? ParseDate(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;

            // Instruction files use dd/MM/yyyy
            if (DateTime.TryParseExact(s.Trim(), "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var d1))
                return d1;

            // Fallback (also covers real Excel date cells where .Text already formatted)
            return DateTime.TryParse(s, CultureInfo.InvariantCulture,
                                     DateTimeStyles.None, out var d2) ? d2 : null;
        }
    }
}
