using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace TelerikTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DataTable selfStudyData;


        List<CarPart> data = new List<CarPart>();
        private string[] columnNames = new string[]
        {
    "Name",
    "Make",
    "PartId"
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000000; i++)
            {
                data.Add(new CarPart()
                {
                    Name = "Name " + i,
                    Make = "Tesla",
                    PartID = i
                });
            }
            this.radGridView1.VirtualMode = true;
            this.radGridView1.CellValueNeeded += RadGridView1_CellValueNeeded; ;
            this.radGridView1.CellValuePushed += RadGridView1_CellValuePushed; ;
            this.radGridView1.ColumnCount = columnNames.Length;
            this.radGridView1.RowCount = data.Count;
        }

        private void RadGridView1_CellValuePushed(object sender, GridViewCellValueEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    data[e.RowIndex].Name = e.Value.ToString();
                    break;
                case 1:
                    data[e.RowIndex].Make = e.Value.ToString();
                    break;
                case 2:
                    data[e.RowIndex].PartID = Convert.ToInt32(e.Value.ToString());
                    break;
                default:
                    break;
            }
        }

        private void RadGridView1_CellValueNeeded(object sender, GridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            if (e.RowIndex == RadVirtualGrid.HeaderRowIndex)
            {
                e.Value = columnNames[e.ColumnIndex];
            }
            if (e.RowIndex >= 0 && e.RowIndex < data.Count)
            {
                e.Value = data[e.RowIndex][e.ColumnIndex];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarPart carPart = new CarPart();
            carPart.Make = "make";
            carPart.Name = "name";
            carPart.PartID = 999;
            data.Add(carPart);
        }
    }

    public class CarPart
    {
        public string Name { get; set; }

        public string Make { get; set; }

        public int PartID { get; set; }

        public string this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return Name;
                    case 1:
                        return Make;
                    case 2:
                        return PartID.ToString();
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
