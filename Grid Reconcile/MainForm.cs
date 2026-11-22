using Grid_Reconcile.Models;
using System.ComponentModel;

namespace Grid_Reconcile
{
    public partial class MainForm : Form
    {
        List<InstructionRow>? instructionRows = new List<InstructionRow>();
        List<SummaryRow>? summaryRows = new List<SummaryRow>();

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
            foreach (var instruction in instructionRows)
            {
                bool matched = false;
                foreach (var summary in summaryRows)
                {
                    if (instruction.RefNo == summary.RefNo)
                    {
                        matched = true;
                        if (instruction.Amount != summary.AccAmount && instruction.DepositedBank != summary.AccName)
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
                                SummeryRowNumber = summary.RowNumber,
                                EnteredBlockType = summary.BlockType,
                                EnteredTxnNo = summary.TxnNo,
                                EnteredRefNo = summary.RefNo,
                                EnteredAccName = summary.AccName,
                                EnteredAccAmount = summary.AccAmount,
                                EnteredNarration = summary.Narration,
                                EnteredBankRealizedDate = summary.BankRealizedDate,
                                EnteredUserName = summary.UserName,
                                Error = "Wrong Amount and Bank"
                            };
                            reconcileResults?.Add(result);
                            break;
                        }
                        else if (instruction.Amount != summary.AccAmount && instruction.DepositedBank == summary.AccName)
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
                                SummeryRowNumber = summary.RowNumber,
                                EnteredBlockType = summary.BlockType,
                                EnteredTxnNo = summary.TxnNo,
                                EnteredRefNo = summary.RefNo,
                                EnteredAccName = summary.AccName,
                                EnteredAccAmount = summary.AccAmount,
                                EnteredNarration = summary.Narration,
                                EnteredBankRealizedDate = summary.BankRealizedDate,
                                EnteredUserName = summary.UserName,
                                Error = "Wrong Amount"
                            };
                            reconcileResults?.Add(result);
                            break;
                        }
                        else if (instruction.Amount == summary.AccAmount && instruction.DepositedBank != summary.AccName)
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
                                SummeryRowNumber = summary.RowNumber,
                                EnteredBlockType = summary.BlockType,
                                EnteredTxnNo = summary.TxnNo,
                                EnteredRefNo = summary.RefNo,
                                EnteredAccName = summary.AccName,
                                EnteredAccAmount = summary.AccAmount,
                                EnteredNarration = summary.Narration,
                                EnteredBankRealizedDate = summary.BankRealizedDate,
                                EnteredUserName = summary.UserName,
                                Error = "Wrong Bank"
                            };
                            reconcileResults?.Add(result);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                
                if (!matched)
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
                        EnteredBankRealizedDate = null,
                        EnteredUserName = "",
                        Error = "Receipt not found"
                    };
                    reconcileResults?.Add(result);
                }
            }

            if (reconcileResults == null)
            {
                MessageBox.Show("No errors found", "Grid Reconcile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConfigureGrid();

            // 2) Bind
            dgvResults.DataSource = _results;

            _results.RaiseListChangedEvents = false;
            foreach (var row in reconcileResults)
                _results.Add(row);
            _results.RaiseListChangedEvents = true;
            _results.ResetBindings();

            this.MaximizeBox = true;
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
    }
}
