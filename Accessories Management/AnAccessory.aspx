<%@ Page Title="" Language="C#" MasterPageFile="~/AccessoryList.Master" AutoEventWireup="true" CodeBehind="AnAccessory.aspx.cs" Inherits="Accessories_Management.AnAccessory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container-fluid" style="width:500px">
        <div class="form-group row">
              <asp:Label ID="lblError" runat="server" CssClass="text-danger" Text=""></asp:Label>
        </div>
       
          <div class="form-group row">
        <label class="col-sm-2 col-form-label">Name</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
      </div>
      <div class="form-group row">
        <label for="inputPassword3" class="col-sm-2 col-form-label">Description</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
     </div>
    <div class="form-group row">
        <label for="inputPassword3" class="col-sm-2 col-form-label">Quantity</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
     </div>
    <div class="form-group row">
        <label for="inputPassword3" class="col-sm-2 col-form-label">Price</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
     </div>
    <div class="form-group row">
        <label for="inputPassword3" class="col-sm-2 col-form-label">Type</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtType" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
     </div>
    <div class="form-group row">
        
        <div class="col-sm-5">
            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
         <div class="col-sm-5">
             <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        &nbsp;
        </div>
     </div>
    </div>
  
</asp:Content>
