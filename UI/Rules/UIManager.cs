using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JT.UniStuttgart.StudentLibrary.Client.UI
{
    public static class UIManager
    {
        public static void FitDatagridview(DataGridView dgv)
        {
            dgv.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        public static void VerifyInputs(Form form)
        {
            IEnumerable<Control> cs = form.Controls.Cast<Control>().Where(x => x is TextBox).OrderBy(x => x.TabIndex);
            foreach (Control c in cs)
            {
                c.BackColor = Color.White;
                if (string.IsNullOrEmpty(c.Text))
                {
                    //isEmpty = true;
                    c.Focus();
                    c.BackColor = Color.FromArgb(232, 125, 125);
                    MessageBox.Show($"Das gekennzeichnete Feld muss gefüllt werden");
                    break;
                }
            }
        }
    }
}
