using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sync_Kafka
{
    public class clsSyncMTC
    {
        /// <summary>
        /// 1: vào, 2: ra /Loại giao dịch 
        /// </summary>
        public int Transaction_Type { get; set; }
        /// <summary>
        /// Mã giao dịch tại trạm
        /// </summary>
        public string Transaction_ID { get; set; }
        /// <summary>
        /// Ngày giờ xe qua  trạm
        /// </summary>
        public string Transaction_Date { get; set; }
        public string Serial { get; set; }
        /// <summary>
        /// Mã trạm
        /// </summary>
        public int Station { get; set; }
        public int Lane { get; set; }
        public string Plate { get; set; }
        public int Work_Shift { get; set; }
        public string Staff_name { get; set; }
        public string Vehicle_Image { get; set; }
        public string Plate_Image { get; set; }
        public int Process_Type { get; set; }
        public int Ticket_Type { get; set; }
        public int Vehicle_Type { get; set; }
        /// <summary>
        /// 0:không khớp, 1: khớp biển số, 2: không nhận diện được
        /// </summary>
        public int Plate_Type { get; set; }
        public int Price { get; set; }
        public string Enter_Transaction_ID { get; set; }
        public int Enter_Station_Id { get; set; }
        public int Enter_Lane_Id { get; set; }
        public string Enter_Transaction_Date { get; set; }
        public string Enter_Serial { get; set; }
        public string Enter_Vehicle_Image { get; set; }
        public string Enter_Plate_Image { get; set; }
        public string Enter_Plate { get; set; }
        public string Enter_Staff_Name { get; set; }
    }
}
