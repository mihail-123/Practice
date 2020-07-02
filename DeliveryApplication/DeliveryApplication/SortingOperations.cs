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
    public partial class SortingOperations : Form
    {
        int operationNum, i = 0;
        private DataGridView dataGrid;
        private ClientInfo clientInfo = new ClientInfo();
        private DataOperations dataOperations = new DataOperations();
        private List<ClientInfo> listClientInfo = new List<ClientInfo>();
        public SortingOperations()
        {
            InitializeComponent();
        }
        public SortingOperations(DataGridView dataGrid, List<ClientInfo> listClientInfo) : this()
        {
            this.dataGrid = dataGrid;
            this.listClientInfo = listClientInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            if (radioButton1.Checked)
            {
                if (comboBox1.SelectedIndex > -1)
                {
                    operationNum = (int)comboBox1.SelectedIndex;
                    var list = dataOperations.Sort(listClientInfo, operationNum * 2);
                    foreach (ClientInfo elem in list)
                    {
                        dataGrid[0, i].Value = i + 1;
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
                    MessageBox.Show("Выберите параметр сортировки!", "Error!");
            }
            else if (radioButton2.Checked)
            {
                if (comboBox1.SelectedIndex > -1)
                {
                    operationNum = (int)comboBox1.SelectedIndex;
                    var list = dataOperations.Sort(listClientInfo, operationNum * 2 + 1);

                    foreach (ClientInfo elem in list)
                    {
                        dataGrid[0, i].Value = i + 1;
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
                    MessageBox.Show("Выберите параметр сортировки!", "Error!");
            }
            else
                MessageBox.Show("Выберите тип сортировки!", "Error!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            FillTable();
        }

        private void SortingOperations_Load(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
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
    }
}
