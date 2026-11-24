using Grid_Reconcile.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Grid_Reconcile.Services
{
    public class SummaryReader
    {
        public static List<SummaryRow> ReadSummary(string fileName)
        { 
            var rows = new List<SummaryRow>();
            
            using var package = new ExcelPackage(new FileInfo(fileName));

            foreach (var ws in package.Workbook.Worksheets)
            {
                if (ws.Dimension == null) continue;
                int lastRow = ws.Dimension.Rows;
                int lastCol = ws.Dimension.Columns;
                if (lastRow < 2) continue;

                for (int row = 2; row <= lastRow; row++)
                {
                    // Read cells as text
                    string c1 = ws.Cells[row, 1].Text?.Trim() ?? "";
                    string c2 = ws.Cells[row, 2].Text?.Trim() ?? "";
                    string c3 = ws.Cells[row, 3].Text?.Trim() ?? "";
                    string c4 = ws.Cells[row, 4].Text?.Trim() ?? "";
                    string c5 = ws.Cells[row, 5].Text?.Trim() ?? "";
                    string c6 = ws.Cells[row, 6].Text?.Trim() ?? "";
                    string c7 = ws.Cells[row, 7].Text?.Trim() ?? "";

                    // Skip fully blank rows (e.g. separator rows between blocks) 
                    if (string.IsNullOrWhiteSpace(c1) &&
                        string.IsNullOrWhiteSpace(c2) &&
                        string.IsNullOrWhiteSpace(c3) &&
                        string.IsNullOrWhiteSpace(c4))
                        continue;

                    // Build the row based on SummaryRow Layout
                    SummaryRow summary = new SummaryRow
                    {
                        RowNumber = row,
                        BlockType = c1,
                        TxnNo = c2,
                        RefNo = c3,
                        AccName = c4,
                        AccAmount = ParseDecimal(c5),
                        Narration = c6,
                        UserName = c7
                    };
                    rows.Add(summary);
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
    }
}
