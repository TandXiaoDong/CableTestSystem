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
        List<ListViewItem> listViewItems;
        private List<ListViewItem> cacheListViewSourceCompleteCh1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewItems = new List<ListViewItem>();
            cacheListViewSourceCompleteCh1 = new List<ListViewItem>();

            this.listView1.Columns.Add("ID");
            this.listView1.Columns.Add("Name");

            this.listView1.GridLines = false;
            this.listView1.FullRowSelect = true;
            this.listView1.View = View.Details;
            this.listView1.Scrollable = true;
            this.listView1.MultiSelect = false;
            this.listView1.HeaderStyle = ColumnHeaderStyle.Clickable;

            this.listView1.Columns[0].Width = this.listView1.Width / 9 - 10;
            this.listView1.Columns[1].Width = this.listView1.Width / 9 - 10;

            this.listView1.VirtualMode = true;

            this.listView1.RetrieveVirtualItem += ListView1_RetrieveVirtualItem;
        }

        private void ListView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (this.listViewItems == null || this.listViewItems.Count == 0)
            {
                return;
            }
            ListViewItem lv = this.listViewItems[e.ItemIndex];
            e.Item = lv;
        }

        private int cacheActualCountCompleteCh2;
        private int cacheCountCh2 = 1;
        private void CacheListViewUpdateSinalCh2(string id,string name)
        {
            this.Invoke(new Action(() =>
            {
                ListViewItem listViewItem = new ListViewItem();
                List<string> list = new List<string>();
                //listViewItem.Text = (channelDataCh2.RevCount + 1).ToString();
                listViewItem.Text = id;
                list.Add(name);

                listViewItem.SubItems.AddRange(list.ToArray());

                this.listViewItems.Add(listViewItem);
                ReSetCompleteCh2(this.listViewItems);
                if (cacheCountCh2 == 100)
                {
                    //ReSetCompleteCh2(this.listViewItems);
                    //this.listView1.Items[this.listView1.Items.Count - 1].EnsureVisible();
                    //cacheCountCh2 = 0;
                }
                cacheCountCh2++;
            }));
        }


        public void ReSetCompleteCh2(IList<ListViewItem> list)
        {
            //this.listView1.VirtualMode = true;
            foreach (var item in list)
            {
                //this.cacheListViewSourceCompleteCh1.Add(item);
                //cacheActualCountCompleteCh2++;
            }

            //this.listViewItems.Clear();
            this.listView1.VirtualListSize = this.listViewItems.Count;//this.cacheListViewSourceCompleteCh1.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0;i < 100;i++)
            {
                CacheListViewUpdateSinalCh2(i.ToString(),"name_"+i);
            }
        }
    }

}
