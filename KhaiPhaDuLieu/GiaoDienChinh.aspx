<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiaoDienChinh.aspx.cs" Inherits="KhaiPhaDuLieu.GiaoDienChinh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 82px;
            text-align: center;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 55px;
        }
        textarea{
            width: 100%;
            height: 400px;
        }
        .scroll{
            display:block;
            margin-top:5px;
            width: 100%;
            height: 400px;
            overflow:scroll;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style3" colspan="3" style="background-color: #008080; color: #FFFFFF; font-size: 30px;">Khai Phá dữ liệu sử dụng thuật toán C4.5</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #800080; color: #FFFFFF; font-size: 20px;width:50%">Dữ Liệu</td>
                    <td class="auto-style2" style="background-color: #800080; color: #FFFFFF; font-size: 20px;width:50%">Xử Lý</td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:GridView ID="GridView1" runat="server" class="scroll" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSolution" runat="server" TextMode="MultiLine" ></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
