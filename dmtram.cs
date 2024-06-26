using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sync_Kafka
{
    public class dmtram
    {
        public int ma_tram { get; set; }
        public string ten_tram { get; set; }
        public int ma_tram_ETC { get; set; }

        public Boolean getRow(DataRow row)
        {
            try
            {
                ma_tram = (int)row["ma_tram"];
                ten_tram = row["ten_tram"].ToString();
                ma_tram_ETC = (int)row["ma_tram_ETC"];

                return true;
            }
            catch { }
            return false;
        }

        public DataTable getData(connectSQL conn)
        {
            string str = "select * from dmtram";

            return conn.GetDataTable(str);
        }
        public static List<dmtram> lstTram(connectSQL conn)
        {
            List<dmtram> l = new List<dmtram>();
            dmtram t = new dmtram();
            DataTable dt = t.getData(conn);
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                if (t.getRow(dt.Rows[i]))
                    l.Add(t);
            }
            return l;

        }

        public static int getMatramETC(List<dmtram> ls, int idtram)
        {

            var d = ls.Find(n => n.ma_tram == idtram);
            if (d != null)
                return d.ma_tram_ETC;
            return 0;
        }
    }
}
