namespace Grid_Reconcile
{
    public partial class MainForm : Form
    {
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
    }
}
