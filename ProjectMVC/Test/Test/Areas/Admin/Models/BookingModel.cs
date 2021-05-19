using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Test.FV;

namespace Test.Areas.Admin.Models
{
    public class BookingModel : DbConnection
    {
        private readonly TourDLContext context = null;
        public BookingModel()
        {
            context = new TourDLContext();
        }

        public List<Booking> ListAll(){
            var list = context.Database.SqlQuery<Booking>("getbooking").ToList();
            return list;
        }
        public void Addbooking(Booking bk)
        { 
            cmd = new SqlCommand("pr_ThemBooking", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTour", bk.MaTour);
            cmd.Parameters.AddWithValue("@SLNguoiLon", bk.SLNguoiLon);
            cmd.Parameters.AddWithValue("@SLTreEm", bk.SLTreEm);
            cmd.Parameters.AddWithValue("@MaLT", bk.MaLT);
            cmd.Parameters.AddWithValue("@MaKH", bk.MaKH);
            cmd.Parameters.AddWithValue("@MaDDDL", bk.MaDDDL);
            cmd.Parameters.AddWithValue("@MaNV", bk.MaNV);
            cmd.Parameters.AddWithValue("@TrangThai", bk.TrangThai);
            cmd.Parameters.AddWithValue("@GiaTien", bk.GiaTien);
            cmd.Parameters.AddWithValue("@NgayBook", bk.NgayBook);
            cmd.Connection = _conn;
            _conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            _conn.Close();
        }
        public void Editbooking(Booking bk)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AUOQ6RH;Initial Catalog=Van;Integrated Security=True");

            cmd = new SqlCommand("pr_UpdateBooking", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaVe", bk.MaVe);
            cmd.Parameters.AddWithValue("@MaTour", bk.MaTour);
            cmd.Parameters.AddWithValue("@SLNguoiLon", bk.SLNguoiLon);
            cmd.Parameters.AddWithValue("@SLTreEm", bk.SLTreEm);
            cmd.Parameters.AddWithValue("@MaLT", bk.MaLT);
            cmd.Parameters.AddWithValue("@MaKH", bk.MaKH);
            cmd.Parameters.AddWithValue("@MaDDDL", bk.MaDDDL);
            cmd.Parameters.AddWithValue("@MaNV", bk.MaNV);
            cmd.Parameters.AddWithValue("@TrangThai", bk.TrangThai);
            cmd.Parameters.AddWithValue("@GiaTien", bk.GiaTien);
            cmd.Parameters.AddWithValue("@NgayBook", bk.NgayBook);
            cmd.Connection = _conn;
            _conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            _conn.Close();
        }

        /// <summary>
        /// Delete booking
        /// </summary>
        /// <param name="bk">trtrtrtr</param>
        public void deletebooking(Booking bk)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AUOQ6RH;Initial Catalog=Van;Integrated Security=True");


            cmd = new SqlCommand("pr_deletbooking", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaVe", bk.MaVe);
            cmd.Connection = _conn;
            _conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            _conn.Close();
        }
    }
}