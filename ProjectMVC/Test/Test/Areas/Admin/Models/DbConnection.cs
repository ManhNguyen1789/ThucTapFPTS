using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

namespace Test.Areas.Admin.Models
{
    public class DbConnection
    {
        //tạo 1 biến tĩnh GetDataTable để sử dụng cho việc lấy bảng (áp dụng cho cả lấy danh sách và tìm kiếm)
        private static string sqlstr = ConfigurationManager.ConnectionStrings["TourDLContext"].ConnectionString;

        protected static SqlConnection _conn;
        protected static SqlCommand cmd = new SqlCommand();
        protected static SqlDataAdapter da = new SqlDataAdapter();
        protected static DataTable datb = new DataTable();
        
        public DbConnection()
        {
            try
            {
                _conn = new SqlConnection(sqlstr);
                _conn.Open();                
            }
            catch (Exception ex)
            {
                string abc = ex.ToString();
            }
        }

        /// <summary>
        /// tạo kết nối với procedure
        /// </summary>
        /// <param name="prcName"> truyền tên procedure của bạn vào đây</param>
        protected void ketnoiproc(string prcName)
        {
            try
            {
                cmd = new SqlCommand(prcName, _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                int rowInfected = cmd.ExecuteNonQuery();
                if (rowInfected > 0)
                {
                    HttpContext.Current.Response.Write("<script>alert('Kết nối Command của bạn là ok');</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('Kết nối Command của bạn lỗi, kiểm tra lại');</script>");
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('Lỗi không thể kết nối" + " message lỗi: " + ex.Message + "');</script>");
            }
        }


        /// <summary>
        /// hàm mở và đóng kết nối cho ConnectionString
        /// </summary>
        protected void close_opensql()
        {
            try
            {
                cmd.Connection = _conn;
                _conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('Lỗi không thể kết nối" + " message lỗi: " + ex.Message + "');</script>");
            }
            finally
            {
                cmd.Dispose();
                _conn.Close();
            }
        }

        /// <summary>
        /// Hàm kết nối procedure trả về một DataTable viết cho load table và tìm kiếm
        /// </summary>
        /// <param name="proceSql"></param>
        /// <returns></returns>
        protected static DataTable GetDataTable(string proceSql)
        {


            _conn = new SqlConnection(sqlstr);
            cmd = new SqlCommand(proceSql, _conn);
            da = new SqlDataAdapter();
            datb = new DataTable();
            try
            {
                _conn.Open();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = proceSql;
                cmd.CommandTimeout = 30000;

                da.SelectCommand = cmd;
                da.Fill(datb);

                cmd.Dispose();
                _conn.Close();
                _conn.Dispose();
                da.Dispose();
                return datb;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('Lỗi không thể kết nối" + " message lỗi: " + ex.Message + "');</script>");
                return null;
            }
        }

        /// <summary>
        /// hàm kiểm tra kết nối command, kết nối với procedure
        /// </summary>
        /// <param name="prcName"> tên procedure của bạn sử dụng để kết nối</param>
        //public void commandExec(string prcName)
        //{
        //    try
        //    {
        //        //_conn.Open();
        //        cmd = new SqlCommand(prcName, _conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        int rowInfected = cmd.ExecuteNonQuery();
        //        if (rowInfected > 0)
        //        {
        //            HttpContext.Current.Response.Write("<script>alert('Kết nối Command của bạn là ok');</script>");
        //        }
        //        else
        //        {
        //            HttpContext.Current.Response.Write("<script>alert('Kết nối Command của bạn lỗi, kiểm tra lại');</script>");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        //cmd.Dispose();
        //        //_conn.Close();
        //    }
        //}


        public DataTable GetDataTableNew(string proceSql)
        {

            SqlCommand cmd = new SqlCommand(proceSql, _conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable datb = new DataTable();
            try
            {               
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = proceSql;
                cmd.CommandTimeout = 30000;

                da.SelectCommand = cmd;
                da.Fill(datb);

                return datb;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('Lỗi không thể kết nối" + " message lỗi: " + ex.Message + "');</script>");
                return null;
            }
            finally
            {
                cmd.Dispose();
                _conn.Close();
                _conn.Dispose();
                da.Dispose();               
            }
        }

    } 
}