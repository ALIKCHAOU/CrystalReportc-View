using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalReport
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        ////https://stackoverflow.com/questions/16218371/displaying-a-crystal-report-using-c-sharp
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {

                    CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    //C:\Users\ali.ECGROUPE\source\repos\CrystalReport\CrystalReport\bin\Debug

                    reportDocument.Load(Application.StartupPath + "\\test.rpt");
                    reportDocument.DataSourceConnections.Clear();
                    // reportDocument.Database.Tables[0].SetDataSource(MyDataSet.Tables[0]);
                    reportDocument.Refresh();
                    //  reportDocument.DataSourceConnections[0].SetConnection("172.17.1.199\\SAGEEM25", "sage", "sa", "P@ssw0rd");
                    reportDocument.SetDatabaseLogon("sa", "P@ssw0rd");
                    reportDocument.SetParameterValue("cpy", "KHA");
                    reportDocument.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                    reportDocument.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }
    }
}

