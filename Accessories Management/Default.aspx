<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AccessoryList.Master" CodeBehind="Default.aspx.cs" Inherits="Accessories_Management.WebForm1" %>

<asp:Content ID="css" ContentPlaceHolderID="css" runat="server">
    <style>
    td
    {
        border: 1px solid black; font-size: 12px;text-align: center;
    }
        table {
            height: 80px; width: 800px; font-size: 15px; border-collapse: collapse; border: 1px solid black;
        }

    </style>
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
        
        <div class="container-fluid align-content-center">
            <div style="display:flex" >
                  <asp:Label ID="lbl2" CssClass="form-control" runat="server" style="z-index: 1; width: 317px" Text="Accessories List"></asp:Label> 
                    <asp:Button ID="btnAdd" runat="server"  Text="Add New Accessory" style="margin-left:10px" CssClass="btn btn-secondary" OnClick="btnAdd_Click" /><br />
            </div>
            
            <div id="table" runat="server" style="margin-top:10px">

            </div>
                        <br />
            <br />
            <asp:Label ID="lblError" runat="server" style=" width: 393px"></asp:Label>
 
                    <div style="display:flex;justify-content:space-around;width:500px;height:90px">
                        <div>
                             <asp:Label ID="lblAccessoryName" CssClass="" runat="server" style="z-index: 1; width: 317px" Text="Please Enter an Accessory Name"></asp:Label>
                        </div>
                        <div style="display:flex;flex-direction:column;justify-content:space-between;align-items:flex-end">
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" style="z-index: 1; width: 169px"></asp:TextBox>
                            <asp:Button ID="btnSearchByName" runat="server" CssClass="btn btn-primary " Text="Search" OnClick="btnSearchByName_Click" />
                        </div>
                    </div>    
            <br />
                       <div style="display:flex;justify-content:space-around;width:500px;height:90px">
                        <div>
                             <asp:Label ID="Label1" CssClass="" runat="server" style="z-index: 1; width: 317px" Text="Please Enter a Accessory Price"></asp:Label>
                        </div>
                        <div style="display:flex;flex-direction:column;justify-content:space-between;align-items:flex-end">
                            <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server" style="z-index: 1; width: 169px"></asp:TextBox>
                            <asp:Button ID="btnSearchByPrice" runat="server" CssClass="btn btn-primary " Text="Search" OnClick="btnSearchByPrice_Click" />
                        </div>
                    </div>    
         
            <br />
                    <div style="display:flex;justify-content:space-around;width:500px;height:90px">
                        <div>
                             <asp:Label ID="Label2" runat="server" style="z-index: 1; width: 317px" Text="Please Enter a Accessory Quantity"></asp:Label>
                        </div>
                        <div style="display:flex;flex-direction:column;justify-content:space-between;align-items:flex-end">
                            <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server" style="z-index: 1; width: 169px"></asp:TextBox>
                            <asp:Button ID="btnSearchByQuantity" runat="server" CssClass="btn btn-primary " Text="Search" OnClick="btnSearchByQuantity_Click" />
                        </div>
                    </div>    
            <br />
                       <div style="display:flex;justify-content:space-around;width:500px;height:90px">
                        <div>
                             <asp:Label ID="Label3"  runat="server" style="z-index: 1; width: 317px" Text="Please Enter a Accessory Type"></asp:Label>
                        </div>
                        <div style="display:flex;flex-direction:column;justify-content:space-between;align-items:flex-end">
                            <asp:TextBox ID="txtType" CssClass="form-control" runat="server" style="z-index: 1; width: 169px"></asp:TextBox>
                            <asp:Button ID="btnSearchByType" runat="server" CssClass="btn btn-primary " Text="Search" OnClick="btnSearchByType_Click" />
                        </div>
                    </div>    
        
            <div style="display:flex;justify-content:space-between;width:500px;margin-top:20px;align-items:normal;flex-direction:row">
                 <asp:Button ID="btnDisplayAll" runat="server" CssClass="btn btn-secondary"  Text="Display All" OnClick="btnDisplayAll_Click"/>
                
            </div>
           
            <br />
            <br />
           
          
        </div>
           
    
</asp:Content>