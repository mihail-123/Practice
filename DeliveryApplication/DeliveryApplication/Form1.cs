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
    public partial class Form1 : Form
    {
        private int i = 0;
        private ClientInfo clientInfo;
        private DataOperations dataOperations = new DataOperations();
        private List<ClientInfo> listClientInfo = new List<ClientInfo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetData dataSet = new SetData(dataGridView1, listClientInfo);
            dataSet.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                clientInfo = new ClientInfo();
                clientInfo.SaveSettings(listClientInfo);
            }
            else
                MessageBox.Show("В таблице нет записей!", "Error!");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                EditData editData = new EditData(dataGridView1, listClientInfo);
                editData.Show();
            }
            else
                MessageBox.Show("Для редактирования в таблице должна быть минимум одна запись!", "Error!");
        }

        private void ascendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                SortingOperations sortOperations = new SortingOperations(dataGridView1, listClientInfo);
                sortOperations.Show();
            }
            else
                MessageBox.Show("Для сортировки в таблице должны быть записи!", "Error!");
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                UserSearch userSearch = new UserSearch(dataGridView1, listClientInfo);
                userSearch.Show();
            }
            else
                MessageBox.Show("Для поиска в таблице должны быть записи!", "Error!");
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                dataGridView1.RowCount = 1;
                listClientInfo.Clear();
                MessageBox.Show("Таблица очищена!", "Error!");
            }
            else
                MessageBox.Show("В таблице нет записей!", "Error!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientInfo = new ClientInfo();
            listClientInfo = clientInfo.ReadFile();
            dataGridView1.RowCount = 1;

            for (i = 0; i < listClientInfo.Count; i++)
            {
                dataGridView1.RowCount++;
                dataGridView1[0, i].Value = i + 1;
                dataGridView1[1, i].Value = listClientInfo[i].ID;
                dataGridView1[2, i].Value = listClientInfo[i].Surname;
                dataGridView1[3, i].Value = listClientInfo[i].FirstName;
                dataGridView1[4, i].Value = listClientInfo[i].Patronymic;
                dataGridView1[5, i].Value = listClientInfo[i].ParcelTypeName;
                dataGridView1[6, i].Value = listClientInfo[i].ParcelWeight;
                dataGridView1[7, i].Value = listClientInfo[i].Distance;
                dataGridView1[8, i].Value = listClientInfo[i].ParcelCost;
                dataGridView1[9, i].Value = listClientInfo[i].DeliveryPeriod;
            }
        }
    }
}
