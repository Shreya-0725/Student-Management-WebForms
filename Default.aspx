<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <th>Name</th>
                <asp:HiddenField ID="hdn" runat="server" />
                <td> <asp:TextBox ID="txtName" runat="server" Required></asp:TextBox></td>
            </tr>

            <tr>
                <th>Age</th>
                <td> <asp:TextBox ID="txtAge" runat="server" Required></asp:TextBox></td>
            </tr>

            <tr>
                <td> <asp:Button ID="btnsave" runat="server" Text="submit" OnClick="btnSave_Click" /></td>
            </tr>
        </table>
            <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" OnRowCommand="grid_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <%# Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Age">
                        <ItemTemplate>
                            <%# Eval("age") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteData" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="EditRecord" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </form>
</body>
</html>
