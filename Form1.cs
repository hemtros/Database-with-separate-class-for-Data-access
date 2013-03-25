using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaturdayM23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student s=new Student();
            s.Name = NameTextbox.Text;
            s.Roll = Convert.ToInt32(RollTextbox.Text);
            s.Age = Convert.ToInt32(AgeTextbox.Text);

            StudentDb sdb=new StudentDb();
            int result=sdb.Insert(s);

            if(result==-1)
            {
                MessageBox.Show("Data cannot be inserted");

            }

            else
            {
                MessageBox.Show(result +"rows inserted");
            }

            LoadListView();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentDb sdb=new StudentDb();
           int result= sdb.Delete(Convert.ToInt32(sndeleteTxtBox.Text));
            
            if(result==-1)
            {
                MessageBox.Show("Row couldn't be deleted");
            }

            else
            {
                MessageBox.Show(result+" row deleted");
            }

            LoadListView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student s= new Student();
            s.Name = NameTextbox.Text;
            s.Roll = Convert.ToInt32(RollTextbox.Text);
            s.Age = Convert.ToInt32(AgeTextbox.Text);
            s.Sn = Convert.ToInt32(SnTextbox.Text);
                
            StudentDb sdb=new StudentDb();
            int result=sdb.Update(s);

            if(result==-1)
            {
                MessageBox.Show("Couldnt be updated");
            }

            else
            {
                MessageBox.Show(result+" Row updated");
            }

            LoadListView();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            LoadListView();
        }

        public void LoadListView()
        {
            listView1.Items.Clear();
            StudentDb sdb = new StudentDb();
            List<Student> listOfStudent = sdb.SelectAll();

            foreach (Student s in listOfStudent)
            {
                ListViewItem row = new ListViewItem();
                row.Text = s.Sn.ToString();
                row.SubItems.Add(s.Name);
                row.SubItems.Add(s.Age.ToString());
                row.SubItems.Add(s.Roll.ToString());

                listView1.Items.Add(row);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListViewItem ls = listView1.SelectedItems[0];
            //SnTextbox.Text = ls.Text;
            //NameTextbox.Text = ls.SubItems[];
        }
    }
}
