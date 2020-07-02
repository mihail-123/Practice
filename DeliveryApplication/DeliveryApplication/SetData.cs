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
    public partial class SetData : Form
    {
        private int i;
        private ClientInfo clientInfo;
        private List<ClientInfo> listClientInfo = new List<ClientInfo>();
        private DataOperations dataOperations = new DataOperations();
        private DataGridView dataGrid;
        public SetData()
        {
            InitializeComponent();
        }
        public SetData(DataGridView dataGrid, List<ClientInfo> listClientInfo):this()
        {
            this.dataGrid = dataGrid;
            this.listClientInfo = listClientInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = listClientInfo.Count;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    if (numericUpDown1.Value > 0 && numericUpDown2.Value > 0)
                    {
                        WriteValues(i);

                        switch (comboBox1.SelectedIndex)
                        {
                            case 0: clientInfo.ParcelTypeName = "Документы"; break;
                            case 1: clientInfo.ParcelTypeName = "Посылка"; break;
                            case 2: clientInfo.ParcelTypeName = "Бандероль"; break;
                        }

                        dataGrid.RowCount++;
                        dataGrid[0, i].Value = i + 1;
                        dataGrid[1, i].Value = listClientInfo[i].ID;
                        dataGrid[2, i].Value = listClientInfo[i].Surname;
                        dataGrid[3, i].Value = listClientInfo[i].FirstName;
                        dataGrid[4, i].Value = listClientInfo[i].Patronymic;
                        dataGrid[5, i].Value = clientInfo.ParcelTypeName;
                        dataGrid[6, i].Value = listClientInfo[i].ParcelWeight;
                        dataGrid[7, i].Value = listClientInfo[i].Distance;
                        dataGrid[8, i].Value = listClientInfo[i].ParcelCost;
                        dataGrid[9, i].Value = listClientInfo[i].DeliveryPeriod;

                        label8.Text = "Тип: " + clientInfo.ParcelTypeName;
                        label8.Text += "\nСтоимость: " + listClientInfo[i].ParcelCost + " грн";
                        label8.Text += "\nСрок доставки: " + listClientInfo[i].DeliveryPeriod + " дней";
                        i++;
                    }
                    else
                        MessageBox.Show("Укажите вес или дистанцию!", "Error!");
                }
                else
                    MessageBox.Show("Выберите тип посылки!", "Error!");
            }
            else
                MessageBox.Show("Поля с информацией о клиенте должны быть заполнены!", "Error!");
        }
        private void WriteValues(int serialNumb)
        {

            clientInfo = new ClientInfo();
            clientInfo.SerialNumb = serialNumb + 1;
            clientInfo.ID = dataOperations.GenerateID(5);
            clientInfo.Surname = textBox1.Text;
            clientInfo.FirstName = textBox2.Text;
            clientInfo.Patronymic = textBox3.Text;
            clientInfo.ParcelType = comboBox1.SelectedIndex;
            clientInfo.ParcelWeight = (double)numericUpDown1.Value;
            clientInfo.Distance = (double)numericUpDown2.Value;
            clientInfo.ParcelCost = dataOperations.CalculateParcelCost(clientInfo.Distance, clientInfo.ParcelWeight, clientInfo.ParcelType);
            clientInfo.DeliveryPeriod = dataOperations.CalculateDeliveryPeriod((int)clientInfo.Distance);

            listClientInfo.Add(clientInfo);
        }

        private void SetData_Load(object sender, EventArgs e)
        {
            label8.Text = "";
        }

        private void SetData_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
