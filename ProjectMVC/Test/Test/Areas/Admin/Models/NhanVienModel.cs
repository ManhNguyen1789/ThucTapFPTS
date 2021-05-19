using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Test.FV;

namespace Test.Areas.Admin.Models
{
    public class NhanVienModel : DbConnection
    {
        private readonly TourDLContext context = null;
        public NhanVienModel()
        {
            context = new TourDLContext();
        }

        /// <summary>
        /// hàm load danh sách nhân viên với procedure: getnhanvien và chả về một dataTable
        /// </summary>
        /// <returns>trả về một DataTable</returns>
        public List<NhanVien> ListAll()
        {
            var list = context.Database.SqlQuery<NhanVien>("getnhanvien").ToList();
            return list;
        }
        //public DataTable timkiemnvtb(string timkiem)
        //{
        //    //DataTable dtb = DbConnection.GetDataTable("pr_timbooktheotennv @Activity='GetColumnList', @timkiem= N'" + timkiem + "'");


        //    var dbconn = new DbConnection();

        //    DataTable dtb =  dbconn.GetDataTableNew("pr_timbooktheotennv @timkiem= N'" + timkiem + "'");

        //    return dtb;
        //}

        public List<NhanVien>danhsachtimkiem (string timkiem)
        {       
            var dbconn = new DbConnection();

            DataTable dtb = dbconn.GetDataTableNew("pr_timbooktheotennv @timkiem= N'" + timkiem + "'");

            List<NhanVien> _listnv = new List<NhanVien>();

            foreach (DataRow _row in dtb.Rows)
            {
                NhanVien _nvrow = new NhanVien();
                _nvrow.MaNV = _row["MaNV"].ToString();
                _nvrow.TenNV = _row["TenNV"].ToString();
                _nvrow.NghiepVu = _row["NghiepVu"].ToString();
                _nvrow.GioiTinh = _row["GioiTinh"].ToString();
                _nvrow.DiaChi = _row["DiaChi"].ToString();
                _nvrow.TaiKhoan = _row["TaiKhoan"].ToString();
                _nvrow.SDT = _row["SDT"].GetHashCode();

                _listnv.Add(_nvrow);
            }                     

            return _listnv;
        }


        //public List<NhanVien> timkiemnv(string timkiem)
        //{
        //    var list = context.Database.SqlQuery<NhanVien>("pr_timbooktheotennv @timkiem='N" + timkiem+"'").ToList();
        //    return list;
        //}

        /// <summary>
        /// Thêm nhân viên với procedure: pr_addnhanvien
        /// </summary>
        /// <param name="nv"></param>
        public void Addnhanvien(NhanVien nv)
        {
            try
            {
                ketnoiproc("pr_addnhanvien");
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@NghiepVu", nv.NghiepVu);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@DiaCHi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@TaiKhoan", nv.TaiKhoan);
                cmd.Parameters.AddWithValue("@SDT", nv.SDT);
                cmd.Parameters.AddWithValue("@MatKhau", nv.PassWord);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('Lỗi không thể thêm," + " message lỗi: " + ex.Message + "');</script>");
            }
            finally
            {
                close_opensql();
            }
        }

        /// <summary>
        /// Chỉnh sửa thông tin nhân viên với procedure: pr_editnhanvien
        /// </summary>
        /// <param name="nv"></param>
        public void Editnhanvien(NhanVien nv)
        {
            try
            {
                ketnoiproc("pr_editnhanvien");
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@NghiepVu", nv.NghiepVu);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@DiaCHi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@TaiKhoan", nv.TaiKhoan);
                cmd.Parameters.AddWithValue("@SDT", nv.SDT);
                cmd.Parameters.AddWithValue("@MatKhau", nv.PassWord);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('Lỗi không thể chỉnh sửa" + " message lỗi: " + ex.Message + "');</script>");
            }
            finally
            {
                close_opensql();
            }
        }

        /// <summary>
        /// Xóa sinh viên theo mã nhân viên với procedure: pr_deletenhanvien
        /// </summary>
        /// <param name="nv"></param>
        public void deletenhanvien(NhanVien nv)
        {
            //SqlConnection con = new SqlConnection(sqlconn);
            try
            {
                ketnoiproc("pr_deletenhanvien");
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('Lỗi không thể chỉnh sửa" + " message lỗi: " + ex.Message + "');</script>");
            }
            finally
            {
                close_opensql();
            }
        }

    }
}