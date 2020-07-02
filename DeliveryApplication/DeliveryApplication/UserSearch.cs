using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryApplication
{
    public partial class UserSearch : Form
    {
        int i = 0;
        private string pattern;
        private int operationNum;
        private DataGridView dataGrid;
        private DataOperations dataOperations = new DataOperations();
        private List<ClientInfo> listClientInfo = new List<ClientInfo>();
        public UserSearch()
        {
            InitializeComponent();
        }
        public UserSearch(DataGridView dataGrid, List<ClientInfo> listClientInfo) :this()
        {
            this.dataGrid = dataGrid;
            this.listClientInfo = listClientInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pattern = textBox1.Text;
            operationNum = (int)comboBox1.SelectedIndex;
            if (operationNum >= 0) // Если вользователь выбрал тип подоперации
            {
                if (textBox1.Text != "")
                {
                    if (operationNum >= 0) // Если вользователь выбрал тип подоперации
                    {
                        dataGrid.Rows.Clear();
                        var linqList = dataOperations.Search(listClientInfo, operationNum, pattern);
                        i = 0;
                        foreach (ClientInfo elem in linqList)
                        {
                            dataGrid.RowCount++;
                            dataGrid[0, i].Value = elem.SerialNumb;
                            dataGrid[1, i].Value = elem.ID;
                            dataGrid[2, i].Value = elem.Surname;
                            dataGrid[3, i].Value = elem.FirstName;
                            dataGrid[4, i].Value = elem.Patronymic;
                            dataGrid[5, i].Value = elem.ParcelTypeName;
                            dataGrid[6, i].Value = elem.ParcelWeight;
                            dataGrid[7, i].Value = elem.Distance;
                            dataGrid[8, i].Value = elem.ParcelCost;
                            dataGrid[9, i].Value = elem.DeliveryPeriod;
                            i++;
                        }
                    }
                    else
                        MessageBox.Show("Выберите параметр для поиска!", "Error!");
                }
                else
                    MessageBox.Show("Введите искомый элемент!", "Error!");
            }
            else
                MessageBox.Show("Выберите параметр для поиска!", "Error!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillTable();
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FillTable();
            this.Close();
        }

        private void UserSearch_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }
        private void FillTable()
        {
            dataGrid.Rows.Clear();
            
            for (int i = 0; i < listClientInfo.Count; i++)
            {
                dataGrid.RowCount++;
                dataGrid[0, i].Value = listClientInfo[i].SerialNumb;
                dataGrid[1, i].Value = listClientInfo[i].ID;
                dataGrid[2, i].Value = listClientInfo[i].Surname;
                dataGrid[3, i].Value = listClientInfo[i].FirstName;
                dataGrid[4, i].Value = listClientInfo[i].Patronymic;
                dataGrid[5, i].Value = listClientInfo[i].ParcelTypeName;
                dataGrid[6, i].Value = listClientInfo[i].ParcelWeight;
                dataGrid[7, i].Value = listClientInfo[i].Distance;
                dataGrid[8, i].Value = listClientInfo[i].ParcelCost;
                dataGrid[9, i].Value = listClientInfo[i].DeliveryPeriod;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }
    }
}
