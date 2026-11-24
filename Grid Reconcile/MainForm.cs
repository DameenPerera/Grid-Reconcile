using Grid_Reconcile.Models;
using System.ComponentModel;

namespace Grid_Reconcile
{
    public partial class MainForm : Form
    {
        List<InstructionRow> instructionRows = new List<InstructionRow>();
        List<SummaryRow> summaryRows = new List<SummaryRow>();

        List<ReconcileResults> reconcileResults = new List<ReconcileResults>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void butOpenInst_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    setLabel(labInst, openDialog.SafeFileName, false);

                    try
                    {
                        instructionRows.Clear();
                        instructionRows = Services.InstructionReader.ReadInstructions(openDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Grid Reconcile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setLabel(labInst, openDialog.SafeFileName, false);
                        return;
                    }

                    setLabel(labInst, openDialog.SafeFileName, true);
                }
            }
        }

        private void butOpenData_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    setLabel(labData, openDialog.SafeFileName, false);

                    try
                    {
                        summaryRows.Clear();
                        summaryRows = Services.SummaryReader.ReadSummary(openDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Grid Reconcile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        setLabel(labInst, openDialog.SafeFileName, false);
                        return;
                    }

                    setLabel(labData, openDialog.SafeFileName, true);
                }
            }
        }

        private void setLabel(Label label, string text, bool loadingDone)
        {
            if (loadingDone)
            {
                label.ForeColor = Color.LightSeaGreen;
                label.Text = setFileNameLength(text);
            }
            else
            {
                label.ForeColor = Color.DarkOrange;
                label.Text = setFileNameLength(text) + " Opening...";
            }
        }

        private string setFileNameLength(string fileName)
        {
            if (fileName.Length > 45)
            {
                return fileName.Substring(0, 45) + "..." + fileName.Substring(fileName.Length - 5);
            }
            else
            {
                return fileName;
            }
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            if (instructionRows == null)
            {
                MessageBox.Show("Upload receipt instructions excel file first", "Grid Reconcile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (summaryRows == null)
            {
                MessageBox.Show("Upload receipt details excel file first", "Grid Reconcile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (instructionRows.Count == 0)
            {
                MessageBox.Show("No receipt instructions found", "Grid Reconcile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (summaryRows.Count == 0)
            {
                MessageBox.Show("No receipt details found", "Grid Reconcile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            panResults.Visible = true;
            reconcileResults.Clear();
            _results.RaiseListChangedEvents = false;
            _results.Clear();

            var summaryByRefno = new Dictionary<string, List<SummaryRow>>(StringComparer.OrdinalIgnoreCase);

            foreach (var summary in summaryRows)
            {
                string key = summary.RefNo.Trim();
                if (string.IsNullOrEmpty(key)) continue;

                if (!summaryByRefno.TryGetValue(key, out var list))
                {
                    list = new List<SummaryRow>();
                    summaryByRefno[key] = list;
                }
                list.Add(summary);
            }

            foreach (var instruction in instructionRows)
            {
                string key = instruction.RefNo.Trim();
                List<SummaryRow>? matches = new List<SummaryRow>();
                if (!string.IsNullOrEmpty(key))
                    summaryByRefno.TryGetValue(key, out matches);

                if (matches == null || matches.Count == 0)
                {
                    ReconcileResults result = new ReconcileResults
                    {
                        SheetName = instruction.SheetName,
                        RowNumber = instruction.RowNumber,
                        EmailDate = instruction.EmailDate,
                        RefNo = instruction.RefNo,
                        CustomerOrGlNarration = instruction.CustomerOrGlNarration,
                        Amount = instruction.Amount,
                        PaymentMethod = instruction.PaymentMethod,
                        BankRealizedDate = instruction.BankRealizedDate,
                        DepositedBank = instruction.DepositedBank,
                        SummeryRowNumber = 0,
                        EnteredBlockType = "",
                        EnteredTxnNo = "",
                        EnteredRefNo = "",
                        EnteredAccName = "",
                        EnteredAccAmount = 0,
                        EnteredNarration = "",
                        EnteredUserName = "",
                        Error = "Receipt not found"
                    };
                    reconcileResults?.Add(result);
                    continue;
                }

                foreach (var summary in matches)
                {
                    string error = "";

                    if (instruction.Amount != summary.AccAmount && !areBanksMatch(instruction.DepositedBank, summary.AccName))
                    {
                        error = "Amount and Bank are wrong";
                    }
                    else if (instruction.Amount != summary.AccAmount && areBanksMatch(instruction.DepositedBank, summary.AccName))
                    {
                        error = "Amount is wrong";
                    }
                    else if (instruction.Amount == summary.AccAmount && !areBanksMatch(instruction.DepositedBank, summary.AccName))
                    {
                        error = "Bank is wrong";
                    }

                    ReconcileResults result = new ReconcileResults
                    {
                        SheetName = instruction.SheetName,
                        RowNumber = instruction.RowNumber,
                        EmailDate = instruction.EmailDate,
                        RefNo = instruction.RefNo,
                        CustomerOrGlNarration = instruction.CustomerOrGlNarration,
                        Amount = instruction.Amount,
                        PaymentMethod = instruction.PaymentMethod,
                        BankRealizedDate = instruction.BankRealizedDate,
                        DepositedBank = instruction.DepositedBank,
                        SummeryRowNumber = summary.RowNumber,
                        EnteredBlockType = summary.BlockType,
                        EnteredTxnNo = summary.TxnNo,
                        EnteredRefNo = summary.RefNo,
                        EnteredAccName = summary.AccName,
                        EnteredAccAmount = summary.AccAmount,
                        EnteredNarration = summary.Narration,
                        EnteredUserName = summary.UserName,
                        Error = error
                    };
                    reconcileResults?.Add(result);
                }
            }

            if (reconcileResults == null || reconcileResults.Count == 0)
            {
                return;
            }

            ConfigureGrid();

            dgvResults.DataSource = _results;

            _results.RaiseListChangedEvents = false;
            foreach (var row in reconcileResults)
                _results.Add(row);
            _results.RaiseListChangedEvents = true;
            _results.ResetBindings();

            panResults.Visible = true;
            dgvResults.Visible = true;
            this.MaximizeBox = true;
        }

        private bool areBanksMatch(string instrcuionBank, string summaryBank)
        {
            if (string.IsNullOrWhiteSpace(instrcuionBank) || string.IsNullOrWhiteSpace(summaryBank))
                return false;

            instrcuionBank = instrcuionBank.Replace(" ", "").ToLowerInvariant();//Avoiding including more space then another
            summaryBank = summaryBank.Replace(" ", "").ToLowerInvariant();//and upper case problem

            return instrcuionBank == summaryBank;
        }

        private readonly BindingList<ReconcileResults> _results = new();
        private void ConfigureGrid()
        {
            dgvResults.AutoGenerateColumns = true;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.RowHeadersVisible = false;
        }

        private void goBack()
        {
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Normal;
            panResults.Visible = false;
            instructionRows.Clear();
            summaryRows.Clear();
            reconcileResults.Clear();
            _results.Clear();
        }
    }
}
