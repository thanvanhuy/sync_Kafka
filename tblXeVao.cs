using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sync_Kafka
{
    public class tblXeVao
    {
        public string BienSoTruoc { get; set; }
        public Byte PTTT { get; set; }
        public string MaThe { get; set; }
        public string MaThe2 { get; set; }
        public string MaThe3 { get; set; }
        public System.Byte PhanLoaiXeTruoc { get; set; }
        public System.Byte PhanLoaiXe { get; set; }
        public System.Byte LanXe { get; set; }
        public DateTime NgayQuaTram { get; set; }
        public string GioQuaTram { get; set; }
        public System.Byte CaTruc { get; set; }
        public string MaNhanVien { get; set; }
        public int Phi { get; set; }
        public Nullable<byte> IdTramRa { get; set; }
        public System.Byte? TinhTrangXeRa { get; set; }
        public string TenHinhXe { get; set; }
        public string TenHinhXeCaBin { get; set; }
        public string TenHinhNDTruoc { get; set; }
        public string TenHinhNDCabin { get; set; }
        public string TenHinhNDSau { get; set; }
        public System.Byte IdTramVao { get; set; }
        public byte? sync { get; set; }
        public string ScannerTime { get; set; }
        public int ScannerID { get; set; }
        public int ScannerOutID { get; set; }
        public int AccBalance { get; set; }
        public string BienSoCabin { get; set; }
        public string BienSoSau { get; set; }
        public string BienSoETC { get; set; }
        public string TicketID { get; set; }
        public string TransId { get; set; }
        public DateTime CommitTime { get; set; }
        public int? OBU { get; set; }
        public int? Turning { get; set; }
        public int? Offline { get; set; }
        public byte? PTTT_MTC { get; set; }
        public string SoVe { get; set; }
        public Int32 ticketType { get; set; }
        public byte? LoaiGD { get; set; }
        public int MaTramVao { get; set; }
        public string LoaiLan { get; set; }
        public string TenNV { get; set; }

        public Boolean getRow(DataRow row)
        {
            try
            {
                BienSoTruoc = row["BienSoTruoc"].ToString();
                PTTT = (byte)row["PTTT"];
                MaThe = row["MaThe"].ToString();
                MaThe2 = row["MaThe2"].ToString();
                MaThe3 = row["MaThe3"].ToString();
                PhanLoaiXeTruoc = (byte)row["PhanLoaiXeTruoc"];
                PhanLoaiXe = (byte)row["PhanLoaiXe"];
                LanXe = (byte)row["LanXe"];
                NgayQuaTram = (DateTime)row["NgayQuaTram"];
                GioQuaTram = row["GioQuaTram"].ToString();
                CaTruc = (byte)row["CaTruc"];
                MaNhanVien = row["MaNhanVien"].ToString();
                Phi = (int)row["Phi"];
                IdTramRa = (byte)(row["IdTramRa"] != DBNull.Value ? (byte)row["IdTramRa"] : 0);
                TinhTrangXeRa = (byte)(row["TinhTrangXeRa"] != DBNull.Value ? (byte)row["TinhTrangXeRa"] : 0);
                TenHinhXe = row["TenHinhXe"].ToString();
                TenHinhXeCaBin = row["TenHinhXeCaBin"].ToString();
                TenHinhNDTruoc = row["TenHinhNDTruoc"].ToString();
                TenHinhNDCabin = row["TenHinhNDCabin"].ToString();
                TenHinhNDSau = row["TenHinhNDSau"].ToString();
                IdTramVao = (byte)(row["IdTramVao"] != DBNull.Value ? (byte)row["IdTramVao"] : 0);
                sync = (byte)(row["sync"] != DBNull.Value ? (byte)row["sync"] : 0);
                //ScannerTime = row["ScannerTime"].ToString();
                //ScannerID = (int)row["ScannerID"];
                //ScannerOutID = (int)row["ScannerOutID"];
                //AccBalance = (int)row["AccBalance"];
                BienSoCabin = row["BienSoCabin"].ToString();
                BienSoSau = row["BienSoSau"].ToString();
                BienSoETC = row["BienSoETC"].ToString();
                TicketID = row["TicketID"].ToString();
                TransId = row["TransId"].ToString();
                CommitTime = (DateTime)row["CommitTime"];
                //OBU = (int)row["OBU"];
                //Turning = (int)row["Turning"];
                Offline = (int)row["Offline"];
                //PTTT_MTC = (byte)row["PTTT_MTC"];
                SoVe = row["SoVe"].ToString();
                ticketType = (int)row["ticketType"];
                LoaiGD = (byte)(row["LoaiGD"] != DBNull.Value ? (byte)row["LoaiGD"] : 0);
                MaTramVao = (int)(row["MaTramVao"] != DBNull.Value ? (int)row["MaTramVao"] : 0);
                LoaiLan = row["LoaiLan"].ToString();
                TenNV = row["TenNV"].ToString();

                return true;
            }
            catch { }
            return false;
        }

        public DataTable getDataETC(connectSQL conn)
        {
            string str = "select top 100 * from View_Xevao_sync where (sync is null or sync = 0) and PTTT = 1  order by NgayQuaTram desc";

            return conn.GetDataTable(str);
        }
        public DataTable getDataMTC(connectSQL conn)
        {
            string str = "select top 100 * from View_Xevao_sync where (sync is null or sync = 0) and PTTT = 1  order by NgayQuaTram desc";

            return conn.GetDataTable(str);
        }
        public Boolean DeleteETCSync(connectSQL conn, List<clsSyncData> lst)
        {
            string str = " ";

            foreach (var e in lst)
            {
                string filename = Path.GetFileName(e.Vehicle_Image);
                int fileExtPos = filename.LastIndexOf(".");
                if (fileExtPos >= 0)
                    filename = filename.Substring(0, fileExtPos);
                str = str + " Delete  tblXeVao_Sync  where TenHinhXeCaBin ='" + filename + "' ";
            }
            return conn.ExecuteNonQuery(str);
        }
        public Boolean DeleteMTCSync(connectSQL conn, List<clsSyncMTC> lst)
        {
            string str = " ";

            foreach (var e in lst)
            {
                string filename = Path.GetFileName(e.Vehicle_Image);
                int fileExtPos = filename.LastIndexOf(".");
                if (fileExtPos >= 0)
                    filename = filename.Substring(0, fileExtPos);
                str = str + " Delete  tblXeVao_Sync  where TenHinhXeCaBin ='" + filename + "' ";
            }
            return conn.ExecuteNonQuery(str);
        }
    }
}
