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
    public partial class EditData : Form
    {
        private List<ClientInfo> listClientInfo = new List<ClientInfo>();
        private ClientInfo clientInfo = new ClientInfo();
        private DataOperations dataOperations = new DataOperations();
        private DataGridView dataGrid;
        private int serialNumb;
        public EditData()
        {
            InitializeComponent();
        }
        public EditData(DataGridView dataGrid, List<ClientInfo> listClientInfo) : this()
        {
            this.dataGrid = dataGrid;
            this.listClientInfo = listClientInfo;
        }

        private void EditData_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = listClientInfo.Count;
            label8.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    if (comboBox1.SelectedIndex >= 0)
                    {
                        if (numericUpDown2.Value > 0 && numericUpDown3.Value > 0)
                        {
                            Edit();
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
            else
                MessageBox.Show("Укажите порядковый номер пользователя!", "Error!");
        }
        private void Edit()
        {
            serialNumb = (int)numericUpDown1.Value - 1;
            listClientInfo[serialNumb].Surname = textBox1.Text;
            listClientInfo[serialNumb].FirstName = textBox2.Text;
            listClientInfo[serialNumb].Patronymic = textBox3.Text;
            listClientInfo[serialNumb].ParcelType = comboBox1.SelectedIndex;
            listClientInfo[serialNumb].ParcelWeight = (double)numericUpDown2.Value;
            listClientInfo[serialNumb].Distance = (double)numericUpDown3.Value;

            listClientInfo[serialNumb].ParcelCost = dataOperations.CalculateParcelCost(listClientInfo[serialNumb].Distance, listClientInfo[serialNumb].ParcelWeight, listClientInfo[serialNumb].ParcelType);
            listClientInfo[serialNumb].DeliveryPeriod = dataOperations.CalculateDeliveryPeriod((int)listClientInfo[serialNumb].Distance);

            for (int i = 0; i < listClientInfo.Count; i++)
            {
                switch (listClientInfo[i].ParcelType)
                {
                    case 0: clientInfo.ParcelTypeName = "Документы"; break;
                    case 1: clientInfo.ParcelTypeName = "Посылка"; break;
                    case 2: clientInfo.ParcelTypeName = "Бандероль"; break;
                }

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
            }
            label8.Text = "Тип: " + clientInfo.ParcelTypeName;
            label8.Text += "\nСтоимость: " + listClientInfo[serialNumb].ParcelCost + " грн";
            label8.Text += "\nСрок доставки: " + listClientInfo[serialNumb].DeliveryPeriod + " дней";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            serialNumb = (int)numericUpDown1.Value - 1;
            textBox1.Text = listClientInfo[serialNumb].Surname;
            textBox2.Text = listClientInfo[serialNumb].FirstName;
            textBox3.Text = listClientInfo[serialNumb].Patronymic;
            comboBox1.SelectedIndex = listClientInfo[serialNumb].ParcelType;
            numericUpDown2.Value = (decimal)listClientInfo[serialNumb].ParcelWeight;
            numericUpDown3.Value = (decimal)listClientInfo[serialNumb].Distance;
            label8.Text = "Тип: " + listClientInfo[serialNumb].ParcelTypeName;
            label8.Text += "\nСтоимость: " + listClientInfo[serialNumb].ParcelCost + " грн";
            label8.Text += "\nСрок доставки: " + listClientInfo[serialNumb].DeliveryPeriod + " дней";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
                Delete();
            else
                MessageBox.Show("Укажите порядковый номер пользователя!", "Error!");
        }
        private void Delete()
        {
            serialNumb = (int)numericUpDown1.Value - 1;
            listClientInfo.RemoveAt(serialNumb);
            numericUpDown1.Maximum = listClientInfo.Count;

            dataGrid.RowCount = 1;
            for (int i = 0; i < listClientInfo.Count; i++)
            {
                switch (listClientInfo[i].ParcelType)
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
            }

            serialNumb = (int)numericUpDown1.Value - 1;
            textBox1.Text = listClientInfo[serialNumb].Surname;
            textBox2.Text = listClientInfo[serialNumb].FirstName;
            textBox3.Text = listClientInfo[serialNumb].Patronymic;
            comboBox1.SelectedIndex = listClientInfo[serialNumb].ParcelType;
            numericUpDown2.Value = (decimal)listClientInfo[serialNumb].ParcelWeight;
            numericUpDown3.Value = (decimal)listClientInfo[serialNumb].Distance;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
