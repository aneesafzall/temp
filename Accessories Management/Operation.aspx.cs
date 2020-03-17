using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Accessories_Management
{
    public partial class Operation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["method"] == "edit")
            {
               
                    Int32 AccessoryID;
              
                    AccessoryID = Convert.ToInt32(Request.QueryString["id"]);
                 
                    Session["AccessoryID"] = AccessoryID;
                   
                    Response.Redirect("AnAccessory.aspx");
               
            }
            else if (Request.QueryString["method"] == "del") 
            {
                clsAccessoryCollection MyAccessory = new clsAccessoryCollection();
                //find the record to be deleted
                MyAccessory.ThisAccessory.Find(Convert.ToInt32(Request.QueryString["id"]));
                //call the delete method of the object
                MyAccessory.Delete();
                //redirect back to the main page
                Response.Redirect("AccessorySearch.aspx");

            }
            Response.Redirect("AccessorySearch.aspx");
        }
    }
}