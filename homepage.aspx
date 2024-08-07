<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="olms.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
                
               <center>
                   <h1> Online Library Management System</h1>
                   <br />
                   <br />
                   <br />
                   <br />
               </center>
            </div>
         </div>
         <div class="row">
            <div class="col-md-4">
               <center>
                  <img width="150px" src="imgs/digital-inventory.png"/>
                  <h4>Digital Book Inventory</h4>
                  <p class="text-justify"> Online Book stock availability status from anywhere without going to the Library.</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150px" src="imgs/search-online.png"/>
                  <h4>Search Books</h4>
                  <p class="text-justify">Get the Name of the books available in the library sitting anywhere.</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150px" src="imgs/defaulters-list.png"/>
                  <h4>Defaulter List</h4>
                  <p class="text-justify"> Admin can know the defaulter students list who not return the book on or before due date.</p>
               </center>
            </div>
         </div>
      </div>
   </section>
   <!--<section>
      <img src="imgs/in-homepage-banner.jpg" class="img-fluid"/>
   </section>
       -->
  
</asp:Content>
