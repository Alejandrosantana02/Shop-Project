using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace ShopProject2._0
{
    public partial class Form1 : Form
    {
        public static List<Item> myList = new List<Item>();
        const string FILENAME = "itemlist.txt";
        public Form1()
        {
            InitializeComponent();
            //loadFile(FILENAME);

            if (!loadFile(FILENAME))
            {
                foreach (Item myItem in myList)
                {
                    //listBox1.Items.Add(myItem.Name);
                    listBox1.Items.Add(priceMaker(myItem.Name, Convert.ToString(myItem.Price)));
                }
            }
            else
            {
                button1.Text = "failed";
            }
        }
        public static bool loadFile(string FILENAME)
        {
            bool error = false;
            try
            {
                FileStream inFile = new FileStream(FILENAME, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                string recordIn;
                string[] fields;
                recordIn = reader.ReadLine();

                while (recordIn != null)
                {
                    fields = recordIn.Split(",");
                    GenItem myItem = new GenItem();
                    myItem.Name = fields[0];
                    myItem.Desc = fields[1];
                    myItem.Price = Convert.ToInt32(fields[2]);
                    myItem.Artstring = fields[3];

                    myList.Add(myItem);
                    recordIn = reader.ReadLine();
                }
                inFile.Close();
                reader.Close();
            }
            catch
            {
                error = true;
            }
            return error;
        }

        public static string priceMaker(string name, string price)
        {
            string endString = name;
            int count = endString.Length;
            for(int i=0; i<(35-count); i++)
            {
                endString += "..";
            }
            endString += price + " COINS";

            return endString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int row = listBox1.SelectedIndex;
                itemDesc.Text = myList[row].Desc;
                myList[row].loadImage();

                itemPictureBx.Image = myList[row].Art;
            }
            else
            {
                MessageBox.Show("Please select an item in the shop!");
            }
            //itemPictureBx.Image = 
            //listBox1.SelectedIndex
        }
    }
}
