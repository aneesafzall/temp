using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accessories_Management
{
    public class clsAccessoryCollection
    {
        clsDataConnection dBConnection;
        //private data member for the current address
        clsAccessories thisAccessory = new clsAccessories();

        public clsAccessories ThisAccessory
        {
            get
            {
                return thisAccessory;
            }
            set
            {
                thisAccessory = value;
            }
        }
        public Int32 Add()
        {
            //this function adds a new record to the database returning the primary key value of the new record

            //var to store the primary key value of the new record
            Int32 PrimaryKey;
            //create a connection to the database
            clsDataConnection NewAddress = new clsDataConnection();
       
            NewAddress.AddParameter("@Description", thisAccessory.Description);
          
            NewAddress.AddParameter("@Name", thisAccessory.Name);
            NewAddress.AddParameter("@Price", thisAccessory.Price);
            NewAddress.AddParameter("@Quantity", thisAccessory.Quantity);
            NewAddress.AddParameter("@Type", thisAccessory.Type);
            
            //execute the query to add the record - it will return the primary key value of the new record
            PrimaryKey = NewAddress.Execute("sproc_tblAccessory_Insert");
            //return the primary key value of the new record
            return PrimaryKey;
        }

        //function for the public Update method
        public void Update()
        {
            //this function updates an existing record specified by the class level variable accessoryID
            //it returns no value

            //create a connection to the database
            clsDataConnection NewAccessory = new clsDataConnection();
         
            NewAccessory.AddParameter("@AccessoryID", thisAccessory.AccessoryID);
         
            NewAccessory.AddParameter("@Description", thisAccessory.Description);
      
            NewAccessory.AddParameter("@Name", thisAccessory.Name);
          
            NewAccessory.AddParameter("@Price", thisAccessory.Price);
           
            NewAccessory.AddParameter("@Quantity", thisAccessory.Quantity);
            
            NewAccessory.AddParameter("@Type", thisAccessory.Type);
           
            //execute the query
            NewAccessory.Execute("sproc_tblAccessory_Update");
        }
        public void Delete()
        ///it is a void function and returns no value
        {
            //initialise the DBConnection
            dBConnection = new clsDataConnection();
            //add the parameter data used by the stored procedure
            dBConnection.AddParameter("@AccessoryID", thisAccessory.AccessoryID);
            //execute the stored procedure to delete the address
            dBConnection.Execute("sproc_tblAccessory_Delete");
        }
        public void FilterByName(string Name,string searchBy)
        ///it accepts a single parameter PostCode and returns no value
        {
            //initialise the DBConnection
            dBConnection = new clsDataConnection();
            //add the parameter data used by the stored procedure

            if (searchBy == "Name")
            {
                dBConnection.AddParameter("@AName", Name);
                //execute the stored procedure to delete the address
                dBConnection.Execute("sproc_tblAccessory_FilterByName");
            }
            else if (searchBy == "Price")
            {
                dBConnection.AddParameter("@val", Name);
                //execute the stored procedure to delete the address
                dBConnection.Execute("sproc_tblAccessory_FilterByPrice");
            }
            else if (searchBy == "Quantity")
            {
                dBConnection.AddParameter("@val", Name);
                //execute the stored procedure to delete the address
                dBConnection.Execute("sproc_tblAccessory_FilterByQuantity");
            }
            else if (searchBy == "Type") 
            {
                dBConnection.AddParameter("@val", Name);
                //execute the stored procedure to delete the address
                dBConnection.Execute("sproc_tblAccessory_FilterByType");
            }
          
        }

        public Int32 Count
        ///it returns the count of records currently in QueryResults
        {
            get
            {
                //return the count of records
                return dBConnection.Count;
            }
        }
        public List<clsAccessories> AccessoryList
        {
            get
            {
                List<clsAccessories> addressList = new List<clsAccessories>();
                Int32 Index = 0;
                while (Index < dBConnection.Count)
                {
                    clsAccessories NewAccessory = new clsAccessories();
                    NewAccessory.AccessoryID = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["AccessoryID"]);
                    //get the house no from the query results
                    NewAccessory.Name = Convert.ToString(dBConnection.DataTable.Rows[Index]["Name"]);
                    //get the street from the query results
                    NewAccessory.Description = Convert.ToString(dBConnection.DataTable.Rows[Index]["Description"]);
                    //get the post code from the query results
                    NewAccessory.Price = Convert.ToDouble(dBConnection.DataTable.Rows[Index]["Price"]);
                    //get the address no from the query results
                    NewAccessory.Quantity = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["Quantity"]);
                    //get the type from the query results
                    NewAccessory.Type = Convert.ToString(dBConnection.DataTable.Rows[Index]["Type"]);
                    //increment the index
                    Index++;
                    //add the address to the list
                    addressList.Add(NewAccessory);
                }
                //return the list of addresses
                return addressList;
            }
        }
    }
}