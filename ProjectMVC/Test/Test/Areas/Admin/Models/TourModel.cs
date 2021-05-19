using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Test.FV;

namespace Test.Areas.Admin.Models
{
    public class TourModel
    {
        private readonly TourDLContext context = null;
        public TourModel()
        {
            context = new TourDLContext();
        }

        public List<Tour> ListAll()
        {
            var list = context.Database.SqlQuery<Tour>("gettour").ToList();
            return list;
        }

        public void Addtour(Tour t)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AUOQ6RH;Initial Catalog=Van;Integrated Security=True");

            SqlCommand com = new SqlCommand("pr_themtour", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaTour", t.MaTour);
            com.Parameters.AddWithValue("@TenTour", t.TenTour);
            com.Parameters.AddWithValue("@MaLoaiTour", t.MaLoaiTour);
            com.Parameters.AddWithValue("@GiaTien", t.GiaTien);
            com.Parameters.AddWithValue("@Minuser", t.Minuser);
            com.Parameters.AddWithValue("@Maxuser", t.Maxuser);
            com.Parameters.AddWithValue("@MoTa", t.MoTa);
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            com.Dispose();
            con.Close();
        }

        public void Edittour(Tour t)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AUOQ6RH;Initial Catalog=Van;Integrated Security=True");

            SqlCommand com = new SqlCommand("SP_updatetour", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaTour", t.MaTour);
            com.Parameters.AddWithValue("@TenTour", t.TenTour);
            com.Parameters.AddWithValue("@MaLoaiTour", t.MaLoaiTour);
            com.Parameters.AddWithValue("@GiaTien", t.GiaTien);
            com.Parameters.AddWithValue("@Minuser", t.Minuser);
            com.Parameters.AddWithValue("@Maxuser", t.Maxuser);
            com.Parameters.AddWithValue("@MoTa", t.MoTa);
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            com.Dispose();
            con.Close();
        }

        public void deletetour(Tour t)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AUOQ6RH;Initial Catalog=Van;Integrated Security=True");

            SqlCommand com = new SqlCommand("pr_deletetour", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MaTour", t.MaTour);
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            com.Dispose();
            con.Close();
        }
    }
}