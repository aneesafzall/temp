using System;
using System.Linq;
using System.Web.UI.WebControls;
namespace Accessories_Management
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear any existing error messages
            lblError.Text = "";
            //if this is the first time the page has been displayed
            if (IsPostBack == false)
            {
                //populate the list and display the number of records found
                lblError.Text = DisplayAccessories("","Name") + " records in the database";
            }
        }

        protected void btnSearchByName_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayAddresses function to the record count var
            RecordCount = DisplayAccessories(txtName.Text,"Name");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        protected void btnSearchByPrice_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayAddresses function to the record count var
            RecordCount = DisplayAccessories(txtPrice.Text,"Price");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        protected void btnSearchByQuantity_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayAddresses function to the record count var
            RecordCount = DisplayAccessories(txtQuantity.Text,"Quantity");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        protected void btnSearchByType_Click(object sender, EventArgs e)
        {
            //declare var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayAddresses function to the record count var
            RecordCount = DisplayAccessories(txtType.Text,"Type");
            //display the number of records found
            lblError.Text = RecordCount + " records found";
        }

        protected void btnDisplayAll_Click(object sender, EventArgs e)
        {
            //var to store the record count
            Int32 RecordCount;
            //assign the results of the DisplayAddresses function to the record count var
            RecordCount = DisplayAccessories("","Name");
            //display the number of records found
            lblError.Text = RecordCount + " records in the database";
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["AccessoryID"] = -1;
            //redirect to the data entry page
            Response.Redirect("AnAccessory.aspx");
        }


        Int32 DisplayAccessories(string val,string searchBy)
        {
            ///this function accepts one parameter - the post code to filter the list on
            ///it populates the list box with data from the middle layer class
            ///it returns a single value, the number of records found

            //create a new instance of the clsAddress
            clsAccessoryCollection MyAccessoryList = new clsAccessoryCollection();
            //var to store the count of records
            Int32 RecordCount;
           
            string Name;
         
            string Description;
           
            double Price;

            int Quantity;

            string Type;
            //var to store the primary key value
            int AccessoryID;
            //var to store the index
            Int32 Index = 0;
            table.InnerHtml = "";

            string tableElement = @"<table>"
            + @"<tbody>
           
                   <tr >
           
                       <td > Accessory ID </ td >
               
                           <td > Name </ td >
                
                            <td> Description </ td >
                 
                             <td> Quantity </ td >
                  
                              <td> Price </ td >
                   
                                <td> Type </ td >
                                <td> </td>
                                <td> </td>
                            </tr >";
                    
            //call the filter by post code method
            MyAccessoryList.FilterByName(val,searchBy);
            //get the count of records found
            RecordCount = MyAccessoryList.Count;
            //loop through each record found using the index to point to each record in the data table
            while (Index < RecordCount)
            {
                AccessoryID = Convert.ToInt32(MyAccessoryList.AccessoryList[Index].AccessoryID);

                Name = Convert.ToString(MyAccessoryList.AccessoryList[Index].Name);
               
                Description = Convert.ToString(MyAccessoryList.AccessoryList[Index].Description);
               
                Price = Convert.ToDouble(MyAccessoryList.AccessoryList[Index].Price);
              
                Quantity = Convert.ToInt32(MyAccessoryList.AccessoryList[Index].Quantity);

                Type= Convert.ToString(MyAccessoryList.AccessoryList[Index].Type);

                //   ListItem NewItem = new ListItem(AccessoryID+", "+ Name + "," + Description + ", " + Price + ", "+Quantity+", "+Type);
                tableElement += "<tr> <td>" + AccessoryID + "</td><td>"+Name+"</td> <td>"+Description+"</td> <td>"+Quantity+"</td> <td>"+Price+"</td><td>"+Type+ @"</td> <td><a href=""Operation.aspx?id=" + AccessoryID + "&method=edit\""+ " class=\"btn btn-link\"> Edit </ td >";
                tableElement += "<td><a href=\"Operation.aspx?id=" + AccessoryID + "&method=del\"" + " class=\"btn btn-danger\"> Delete </ td > </tr>";
                //increment the index
                Index++;
            }
            tableElement += "</tbody></table>";

            table.InnerHtml = tableElement;
            //return the number of records found
            return RecordCount;

        }
    }
}