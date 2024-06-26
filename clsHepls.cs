using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sync_Kafka
{
    public static class clsHepls
    {
        public static string pathImg = "http://10.10.19.142:74/Media/Vehicle_Image";
        public static string pathImgPlate = "http://10.10.19.142:74/Media/Plate_Image";
        public static string PathRoot = "http://10.10.19.142:74/Media/";
        public static string UrlServer = "http://10.10.19.142";
        public enum enumProdess_Type
        {
            theluot = 1,
            theluotHu = 2,
            thuluotMat = 3,
            theGiayKhongNhanBiet = 4,
            uuTien1xeKhongNhanBiet = 5,
            uuTien1xeNhanBiet = 6,
            uuTienDoan = 7,
            moSuCoKhongThe = 8,
            moSucoTaoOffline = 9,
            moSucoNapTien = 10,
            ETChopLeDocThe = 11,
            ETChopLeBienSo = 12,
            ETCXeUuTien = 13,
        }
        public enum enumTicketType
        {
            ChuaXacDinh = 0,
            Veluot = 1,
            Vethang = 2,
            VeQuy = 3,
            veNam = 4
        }


        public static Boolean copyImage(string source, string destination)
        {
            try
            {
                if (!System.IO.Directory.Exists(destination))
                {
                    System.IO.Directory.CreateDirectory(destination);
                }
                System.IO.File.Copy(source, destination, true);
            }
            catch { }
            return false;
        }

        public static string getImage(string folder, string str)
        {
            if (str.Length < 14)
            {
                return "";
            }
            string strFileName;
            string strSubFolder;
            strSubFolder = str.Substring(4, 6);
            strFileName = folder + "/" + strSubFolder + "/" + str + ".jpg";
            return strFileName;
        }
        public static enumProdess_Type getPorcessType(tblXeVao xe)
        {
            if (xe.PTTT == 1)
            {
                if (xe.TicketID == "0")
                {
                    return enumProdess_Type.ETCXeUuTien;
                }
                else
                    return enumProdess_Type.ETChopLeDocThe;
            }
            else if (xe.PTTT == 200) // sự cố ETC
            {
                switch (xe.Phi)
                {
                    case 996:
                        return enumProdess_Type.uuTien1xeNhanBiet;
                    case 997:
                        return enumProdess_Type.uuTien1xeNhanBiet;
                    case 998:
                        return enumProdess_Type.uuTienDoan;
                    case 999:
                        return enumProdess_Type.uuTien1xeKhongNhanBiet;
                    case 91:
                        return enumProdess_Type.moSuCoKhongThe;
                    case 92:
                        return enumProdess_Type.moSucoNapTien;
                    case 93:
                        return enumProdess_Type.moSucoTaoOffline;
                    default:
                        return enumProdess_Type.moSucoTaoOffline;
                }
            }

            return 0;
        }

        public static int getLoaive(tblXeVao xe)
        {
            if (xe.PTTT == 0 && xe.TicketID != "0")
            {
                return (int)enumTicketType.Veluot;
            }
            return (int)enumTicketType.ChuaXacDinh;
        }
        public static int getTrangThaiNhanDang(string bs, string bsETC)
        {
            try
            {
                if (bs == "")
                {
                    return 2;// không nhận diện diện
                }
                if (bs == bsETC.Substring(0, bsETC.Length - 1))
                {
                    return 1;// không nhận diện diện
                }
                else
                {
                    return 0;// không khớp
                }
            }catch (Exception)
            {
                return 2;// không nhận diện diện
            }
        }

        public static bool IsValidJson(this string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) return false;

            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    //    var obj = JsonConvert.DeserializeObject<T>(strInput);
                    return true;
                }
                catch // not valid
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
