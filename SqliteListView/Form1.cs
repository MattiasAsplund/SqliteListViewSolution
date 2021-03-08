using SqliteListView.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace SqliteListView
{
    public partial class Form1 : Form
    {
        private MyDbContext _ctx;
        public Form1()
        {
            _ctx = new MyDbContext();
            InitializeComponent();
        }

        private void CreateAndPopulateSqliteDatabase(object sender, EventArgs e)
        {
            _ctx.Database.EnsureCreated();
            var prefixes = new string[] { "Adam", "Bob", "Cesar" };
            foreach (var outerPrefix in prefixes)
            {
                foreach (var innerPrefix in prefixes)
                {
                    var person = new Person() { FullName = $"{outerPrefix}son, {innerPrefix}" };
                    _ctx.People.Add(person);
                    _ctx.SaveChanges();
                }
            }
        }

        private void PopulateListView(object sender, EventArgs e)
        {
            var listViewItemCollection = new ListViewItemCollection(listView1);
            foreach (var item in _ctx.People)
            {
                listViewItemCollection.Add(new ListViewItem() { Text = item.FullName });
            }
        }
    }
}
