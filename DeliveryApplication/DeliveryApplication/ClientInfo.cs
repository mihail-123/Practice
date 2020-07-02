using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace DeliveryApplication
{
    [Serializable]
    public class ClientInfo
    {
        private int serialNumb;
        public int SerialNumb { get{ return serialNumb; } set {if (value > 0)serialNumb = value;} }
        private string iD;
        public string ID { get { return iD; } set { if (value != "") iD = value; } }
        private string surname;
        public string Surname { get { return surname; } set { if (value != "") surname = value; } }
        private string firstName;
        public string FirstName { get { return firstName; } set { if (value != "") firstName = value; } }
        private string patronymic;
        public string Patronymic { get { return patronymic; } set { if (value != "") patronymic = value; } }
        private int parcelType;
        public int ParcelType { get { return parcelType; } set { if (value >= 0) parcelType = value; } }
        private double parcelWeight;
        public double ParcelWeight { get { return parcelWeight; } set { if (value > 0.0d) parcelWeight = value; } }
        private double distance;
        public double Distance { get { return distance; } set { if (value > 0.0d) distance = value; } }
        private double parcelCost;
        public double ParcelCost { get { return parcelCost; } set { if (value > 0.0d) parcelCost = value; } }
        private int deliveryPeriod;
        public int DeliveryPeriod { get { return deliveryPeriod; } set { if (value > 0) deliveryPeriod = value; } }
        private string parcelTypeName;
        public string ParcelTypeName { get { return parcelTypeName; } set { if (value != "") parcelTypeName = value; } }
        public ClientInfo()
        {

        }
        public ClientInfo(int serialNumb, string id, string surname, string firstName, string patronymic, int parcelType,
            double parcelWeight, double distance, double parcelCost, int deliveryPeriod, string parcelTypeName)
        {
            SerialNumb = serialNumb;
            ID = id;
            Surname = surname;
            FirstName = firstName;
            Patronymic = patronymic;
            ParcelType = parcelType;
            ParcelWeight = parcelWeight;
            Distance = distance;
            ParcelCost = parcelCost;
            DeliveryPeriod = deliveryPeriod;
            ParcelTypeName = parcelTypeName;
        }
        public void SaveSettings(List<ClientInfo> listClientInfo)
        {
            SaveFileDialog save = new SaveFileDialog();
            string Fname = "";//Имя файла
            save.InitialDirectory = @"С:\";// задание начальной директории
            save.Filter = "xml files (*.xml)|*.xml";// задание свойства Filter
            save.FilterIndex = 2;// выбор типа файла
            save.Title = "Сохранить файл как";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Fname = save.FileName;
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<ClientInfo>));
                using (FileStream fs = new FileStream(Fname, FileMode.Create, FileAccess.Write))

                    if (fs != null)
                    {
                        StreamWriter wr = new StreamWriter(fs);
                        try
                        {
                            xmlFormatter.Serialize(fs, listClientInfo);
                            MessageBox.Show("Данные сохранены!", "Complate!");
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка сохранения файла!", "Error!");
                        }
                        wr.Flush();
                        wr.Close();
                        fs.Close();
                    }
            }
        }
        public List<ClientInfo> ReadFile()
        {
            OpenFileDialog open = new OpenFileDialog();
            string Fname = ""; // Имя файла
            open.InitialDirectory = @"С:\";// задание начальной директории
            open.Filter = "xml files (*.xml)|*.xml"; // задание свойства Filter
            open.FilterIndex = 2;// выбор типа файла
            open.Title = "Открыть файл";

            List<ClientInfo> fileData = new List<ClientInfo>();
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<ClientInfo>));

            if (open.ShowDialog() == DialogResult.OK)
            {
                Fname = open.FileName;
                FileStream fs = new FileStream(Fname, FileMode.Open, FileAccess.Read);

                try
                {
                    fileData = (List<ClientInfo>)xmlFormatter.Deserialize(fs);
                    MessageBox.Show("Данные считаны!", "Complate!");
                }
                catch
                {
                    MessageBox.Show("Ошибка чтения файла!", "Error!");
                }
                fs.Close();
            }
            return fileData;
        }
    }
}
