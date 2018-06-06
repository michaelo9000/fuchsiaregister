<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="mystyle.css" />
    <title>Home | Fuchsia Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="pass">
            <asp:Label ID="userLabel" runat="server" Text="Beardie"></asp:Label>
            <asp:Label ID="passLabel" runat="server" Text="Oliver"></asp:Label>
        </div>
        <div id="literal">
        <asp:Literal ID="Literal1" runat="server" Text="
            &lt;div class=&quot;helpLabel&quot; id=&quot;leftLabel&quot;&gt;&lt;img src=&quot;images/qMark.png&quot; /&gt;
                Change the size of the text displayed in the table.
                Log in as Admin to change the data file and upload more images.
                To disable these tips, click 'Help!' again.
            &lt;/div&gt;
            &lt;div class=&quot;helpLabel&quot; id=&quot;centerLabel&quot;&gt;&lt;img src=&quot;images/qMark.png&quot; /&gt;
                Click the 'Select' button beside any of the flowers in the table to see images.
                If one or more images are available, the corresponding buttons will become clickable.
            &lt;/div&gt;
            &lt;div class=&quot;helpLabel&quot; id=&quot;centerLabel2&quot;&gt;&lt;img src=&quot;images/qMark.png&quot; /&gt;
                The green box will show the flower you have selected. The search button will take you to
                a google image search for 'fuchsia' and the name of the selected flower.
            &lt;/div&gt;
            &lt;div class=&quot;helpLabel&quot; id=&quot;tableLabel&quot;&gt;&lt;img src=&quot;images/qMark.png&quot; /&gt;
                To search the register, press ctrl & F on your keyboard to open the 'Find' toolbar.
                With this you can search for text on the page; note that it will only return exact matches.
            &lt;/div&gt;

        " Visible="False"></asp:Literal>
            </div>
        <div id="header">
            <div id="left">
                <asp:DropDownList ID="DropDownList1" runat="server" 
                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>change text size...</asp:ListItem>
                <asp:ListItem>Small</asp:ListItem>
                <asp:ListItem>Medium (Default)</asp:ListItem>
                <asp:ListItem>Large</asp:ListItem>
                <asp:ListItem>Monstrous</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Button7" runat="server" Text="Help!" OnClick="Button7_Click" CssClass="cursor" />
            </div>
            <div id="nav">
            <table>
                <tr>
                    <td id="errorBox" colspan="2">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                    <td id="selectedBox">
                        <asp:Label ID="Label2" runat="server" Text="selected flower"></asp:Label>
                    </td>
                    <td class="imageButton">
                        <asp:Button ID="Button3" runat="server" OnClick="search_Click" 
                            Text="Search Online" OnClientClick="target='_blank'" CssClass="cursor"/>
                    </td>
                </tr>
                <tr>
                    <td class="imageButton">
                        <asp:Button ID="Button1" runat="server" OnClick="image1_Click" Text=" " OnClientClick="target='_blank'" Enabled="False"/>
                    </td>
                    <td class="imageButton">
                        <asp:Button ID="Button4" runat="server" OnClick="image2_Click" Text=" " OnClientClick="target='_blank'" Enabled="False"/>
                    </td>
                    <td class="imageButton">
                        <asp:Button ID="Button5" runat="server" OnClick="image3_Click" Text=" " OnClientClick="target='_blank'" Enabled="False"/>
                    </td>
                    <td class="imageButton">
                        <asp:Button ID="Button6" runat="server" OnClick="image4_Click" Text=" " OnClientClick="target='_blank'" Enabled="False"/>
                    </td>
                </tr>
            </table>
            </div>
        </div>
        <div id="admin">  
            <div id="p">Admin</div>
            
                <asp:TextBox ID="userTextBox" runat="server">Admin Username</asp:TextBox>
                <asp:TextBox ID="passTextBox" runat="server">Admin Password</asp:TextBox>
                <asp:Button CssClass="cursor" ID="loginButton" runat="server" Text="Log In" OnClick="login_Click" />
                <asp:Button CssClass="cursor" ID="logoutButton" runat="server" Text="Log Out" OnClick="logout_Click" />
                <asp:FileUpload ID="upload" runat="server" Enabled="false"/>
                <asp:Button ID="imageUpload" runat="server" Enabled="false" OnClick="upload_Click" Text="Upload Image" />
                <asp:Button ID="csvUpload" runat="server" Enabled="false" Text="Overwrite Register" OnClick="csvUpload_Click" />
            
        </div>
        <div id="main">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Size="Medium" Font-Bold="True">
            <SelectedRowStyle CssClass="selectedRow" Font-Bold="false" BackColor="#92C75C" BorderColor="Black" ForeColor="White" />
        </asp:GridView>
    </div>
        
    </form>
</body>
</html>
