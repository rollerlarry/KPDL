using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Collections;
namespace KhaiPhaDuLieu
{
    public class TruyVanCSDL
    {
        private string OpenExcelFile(string fPath)
        {
            string connectionstring = String.Empty;
            string[] splitdot = fPath.Split(new char[1] { '.' });
            string dot = splitdot[splitdot.Length - 1].ToLower();
            if (dot == "xls")
            {
                //tao chuoi ket noi voi Excel 2003
                connectionstring = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + fPath + "; Extended Properties =\"Excel 8.0; HDR = Yes; IMEX = 1\"";
            }
            else if (dot == "xlsx")
            {
                //tao chuoi ket noi voi Excel 2007
                connectionstring = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + fPath + "; Extended Properties =\"Excel 8.0; HDR = YES; IMEX = 1\"";
            }
            return connectionstring;
        }
        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name=”fUpload”>The upload control .</param>
        /// <param name=”fPath”>The path string.</param>
        public string UploadFile(FileUpload fUpload)
        {
            string fPath = String.Empty;
            try
            {
                fPath = HttpContext.Current.Server.MapPath("~/ upload / temp /" + fUpload.FileName);
                FileInfo fInfo = new FileInfo(fPath);
                if (fInfo.Exists)
                {
                    fInfo.Delete();
                }
                fUpload.SaveAs(fPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return fPath;
        }
        /// <summary>
        /// Gets the name of the sheet.
        /// </summary>
        /// <param name=”fPath”>The f path.</param>
        /// <returns>return all sheet name</returns>
        public ArrayList GetSheetName(string fPath)
        {
            ArrayList sheetnames = new ArrayList();
            string connectionstring = OpenExcelFile(fPath);
            //mo ket noi den file excel
            OleDbConnection cnn = new OleDbConnection(connectionstring);
            cnn.Open();

            //tao bang luu tru tam cac du lieu trong file
            DataTable table = new DataTable();
            table = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //doc tung dong trong bang luu tru tam
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string name = table.Rows[i][2].ToString().Replace("‘", "");//get ten tung sheet co trong bang luu tru
                                                                           //kiem tra sheet
                if (name.EndsWith("$"))
                {
                    sheetnames.Add(name.Replace("$", ""));
                }
            }
            cnn.Close();
            table.Dispose();
            return sheetnames;
        }
        /// <summary>
        /// Gets the data excel.
        /// </summary>
        /// <param name=”fPath”>The f path.</param>
        /// <param name=”sheetname”>The sheetname.</param>
        /// <returns>return dataset</returns>
        public DataSet GetDataExcel(string fPath, string sheetname)
        {
            DataSet ds = new DataSet();
            string connectionstring = OpenExcelFile(fPath);
            string query = "SELECT* FROM[" + sheetname + "$]";
            using (OleDbConnection cnn = new OleDbConnection(connectionstring))
            {
                //cnn.Open();
                OleDbDataAdapter oleAdapter = new OleDbDataAdapter(query, cnn);
                oleAdapter.Fill(ds, sheetname);
                oleAdapter.Dispose();
                cnn.Close();
                cnn.Dispose();
            }
            return ds;

        }
    }
}