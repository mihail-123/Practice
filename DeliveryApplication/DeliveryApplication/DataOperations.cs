using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryApplication
{
    public class DataOperations
    {
        public string GenerateID(int count)
        {
            string parameters = "1234567890QAZWSXEDCRFVTGBYHNUJMIKOLP";
            string result = "";

            Random rand = new Random();
            int lng = parameters.Length;

            for (int i = 0; i < count; i++)
            {
                result += parameters[rand.Next(lng)];
            }
            return result;
        }

        public double CalculateParcelCost(double distance, double parcelWeight, int index)
        {
            double parcleCost = 0;
            if (index == 0)
                parcleCost = 27 + distance * 0.03;

            if (index == 1)
            {
                if (parcelWeight > 30)
                    parcleCost = parcelWeight * 1.4 + distance * 0.04;
                else
                    parcleCost = 29 + distance * 0.03;
            }

            if (index == 2)
                parcleCost = 29 + parcelWeight * 1.1 + distance * 0.03;
            return parcleCost;
        }
        public int CalculateDeliveryPeriod(int distance)
        {
            int deliveryPeriod = 0;
            if (distance > 1000)
                deliveryPeriod = distance / 1000;
            else
                deliveryPeriod = 1;
            return deliveryPeriod;
        }

        public IEnumerable<ClientInfo> Sort(List<ClientInfo> data, int operationNum)// Метод сортировки в зависимости от выбранных параметров
        {
            switch (operationNum)
            {
                case 0: return data.OrderBy(d => d.Surname);
                case 1: return data.OrderByDescending(d => d.Surname);

                case 2: return data.OrderBy(d => d.FirstName);
                case 3: return data.OrderByDescending(d => d.FirstName);

                case 4: return data.OrderBy(d => d.Patronymic);
                case 5: return data.OrderByDescending(d => d.Patronymic);

                case 6: return data.OrderBy(d => d.ParcelWeight);
                case 7: return data.OrderByDescending(d => d.ParcelWeight);

                case 8: return data.OrderBy(d => d.Distance);
                case 9: return data.OrderByDescending(d => d.Distance);

                case 10: return data.OrderBy(d => d.ParcelCost);
                case 11: return data.OrderByDescending(d => d.ParcelCost);

                case 12: return data.OrderBy(d => d.DeliveryPeriod);
                case 13: return data.OrderByDescending(d => d.DeliveryPeriod);
            }
            return null;
        }
        public IEnumerable<ClientInfo> Search(List<ClientInfo> data, int operationNum, string pattern)// Фильтрация в зависимости от выбранных параметров
        {
            switch (operationNum)
            {
                case 0: return data.Where(d => d.Surname.StartsWith(pattern));
                case 1: return data.Where(d => d.FirstName.StartsWith(pattern));
                case 2: return data.Where(d => d.Patronymic.StartsWith(pattern));
            }
            return null;
        }
    }
}
