using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeBoston.DATA;

namespace CafeBoston.UI
{
    public partial class MainForm : Form
    {
        CafeData db = new CafeData();

        public MainForm()
        {
            InitializeComponent();
            SeedSampleProducts();
            LoadTables();
        }

        private void SeedSampleProducts()
        {
            db.Products.Add(new Product() { ProductName = "Cola", UnitPrice = 14.50m });
            db.Products.Add(new Product() { ProductName = "Tea", UnitPrice = 9m });
        }

        private void LoadTables()
        {
            for (int i = 1; i <= db.TableCount; i++)
            {
                var lvi = new ListViewItem($"Table {i}");
                lvi.Tag = i;
                lvi.ImageKey = "empty";
                lvwTables.Items.Add(lvi);
            }
        }

        private void lvwTables_DoubleClick(object sender, EventArgs e)
        {
            var selectedLvi = lvwTables.SelectedItems[0];
            int tableNo = (int)selectedLvi.Tag;
            MessageBox.Show(tableNo.ToString());
            //var frmOrder = new OrderForm();
            //frmOrder.ShowDialog();
        }
    }
}
