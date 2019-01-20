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
    public partial class GiaoDienChinh : System.Web.UI.Page
    {
        TruyVanCSDL TruyVan = new TruyVanCSDL();
        List<Attribute> Attributes = new List<Attribute>();
        //DecisionTreeID3 DTID3;
        C45 GTC45;
        List<List<string>> Examples = new List<List<string>>();
        int Height, Width = 0;
        string name, dtb, dm1, dm2, dm3;
        //DuLieuDiem[] data = new DuLieuDiem[4];
        string[] gt_XuLy = new string[4];
        protected void Page_Load(object sender, EventArgs e)
        {
            //Đường dẫn tới file nguồn chứa dữ liệu huần luyện
            string DuongDanFileHuanLuyen = @"C:\Users\Justin Kai\Desktop\BAOCAOKPDL_DETAI5_DUDOANTHOIGIANNAMVIEN_HP_KPDL_SUPHAMK38\BAO CAO KPDL\DuLieuLon - Copy.xlsx";
            //Tên sheet của file excel chứa dữ liệu huấn luyện (Mở file Excel và coi ở góc dưới bên trái)
            string SheetCuaExcel = "DuLieuLon";
            GridView1.DataSource = TruyVan.GetDataExcel(DuongDanFileHuanLuyen, SheetCuaExcel);
            GridView1.DataBind();

            
            Attribute temp = new Attribute();
            temp.Name = "DANTOC";
            Attributes.Add(temp);
            temp.Name = "NOIO";
            Attributes.Add(temp);
            temp.Name = "TINHTHANH";
            Attributes.Add(temp);
            temp.Name = "DOTUOI";
            Attributes.Add(temp);
            temp.Name = "CHUANDOAN";
            Attributes.Add(temp);
            temp.Name = "THOIGIANNAMVIEN";
            Attributes.Add(temp);


            for (int i = 0; i < GridView1.Rows.Count ; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Attributes[j].AddValue(GridView1.Rows[i].Cells[j].Text.ToString().ToLower());
                    //txtSolution.Text += Attributes[j].Value[i].ToString() + "\n";
                }
            }

            /*for (int i = 0; i < 6; i++)
            {
                for(int j = 0; j < Attributes[i].Value.Count; j++)
                    txtSolution.Text += Attributes[i].Value[j].ToString() + "\n";
            }*/

            txtSolution.Text += Attributes[1].Value.Count.ToString();
            for (int j = 0; j < Attributes[1].Value.Count; j++) ;
                txtSolution.Text += Attributes[0].ToString() + "\n";

            /*for(int i = 0; i < 6; i++)
           {
               for(int j = 0; j < Attributes[i].Value.Count; j++)
               {*/
            //txtSolution.Text = Attributes[0].Value[0].ToString() + "\n";
            /*   }
           }*/


            //txtSolution.Text = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                List<string> example = new List<string>();
                for (int j = 0; j < 6; j++)
                {
                    example.Add(GridView1.Rows[i].Cells[j].Text.ToString().ToLower());
                    //txtSolution.Text += GridView1.Rows[i].Cells[j].Text.ToString().ToLower() + "\n";

                }
                Examples.Add(example);

            }
            
            //txtSolution.Text = Examples[0].Count.ToString();
            /*List<Attribute> at = new List<Attribute>();
            for (int i = 0; i < Attributes.Count; i++)
            {
                at.Add(Attributes[i]);
            }
            GTC45 = new C45(Examples, at);
            GTC45.GetTree();
            txtSolution.Text = GTC45.Solution;
            //btDuDoan.Enabled = true;*/
        }
    }
}