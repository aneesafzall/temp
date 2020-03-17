using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Accessories_Management
{
    public partial class AnAccessory : System.Web.UI.Page
    {
        int AccessroryID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //get the address no from the session object
            AccessroryID = Convert.ToInt32(Session["AccessoryID"]);
            //if this is the first time the page has loaded
            if (IsPostBack == false)
            {
                //if we are not adding a new record
                if (AccessroryID != -1)
                {
                    //update the fields on the page with the data from the record
                    DisplayAccessory();
                }
               
            }
        }

        private void DisplayAccessory()
        {
            clsAccessoryCollection MyAccessory = new clsAccessoryCollection();
            //find the record we want to display
            MyAccessory.ThisAccessory.Find(AccessroryID);
            txtName.Text = MyAccessory.ThisAccessory.Name;
            txtDescription.Text = MyAccessory.ThisAccessory.Description;
            txtPrice.Text = MyAccessory.ThisAccessory.Price.ToString();
            txtQuantity.Text = MyAccessory.ThisAccessory.Quantity.ToString();
            txtType.Text = MyAccessory.ThisAccessory.Type;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //var to store any error messages
            string ErrorMsg;
            //create an instance of the address class
            clsAccessoryCollection Accessory = new clsAccessoryCollection();
            //use the objects validation method to test the data
            ErrorMsg = Accessory.ThisAccessory.Valid(txtDescription.Text, txtName.Text,txtPrice.Text,txtQuantity.Text, txtType.Text);
            //if there is no error message
            if (ErrorMsg == "")
            {
                //if we are adding a new record
                if (AccessroryID == -1)
                {
                  
                    Accessory.ThisAccessory.Description = txtDescription.Text;
                   
                    Accessory.ThisAccessory.Name = txtName.Text;
                   
                    Accessory.ThisAccessory.Price = Convert.ToDouble(txtPrice.Text);
                   
                    Accessory.ThisAccessory.Quantity = Convert.ToInt32(txtQuantity.Text);
                  
                    Accessory.ThisAccessory.Type =txtType.Text;
               
                    Accessory.Add();
                }
                else//this is an existing record to update
                {
                    
                    Accessory.ThisAccessory.Find(AccessroryID);
                    
                    Accessory.ThisAccessory.Name = txtName.Text;
                   
                    Accessory.ThisAccessory.Description = txtDescription.Text;

                    Accessory.ThisAccessory.Price = Convert.ToDouble(txtPrice.Text);

                    Accessory.ThisAccessory.Quantity = Convert.ToInt32(txtQuantity.Text);

                    Accessory.ThisAccessory.Type = txtType.Text;
                  
                    Accessory.Update();
                }
                //all done so redirect back to the main page
                Response.Redirect("AccessorySearch.aspx");
            }
            else//there are errors
            {
                //display the error message
                lblError.Text = ErrorMsg;
            }
            
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect to the main page
            Response.Redirect("AccessorySearch.aspx");
        }

        
       

        
    }
}