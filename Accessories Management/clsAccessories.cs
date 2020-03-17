using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accessories_Management
{
    public class clsAccessories
    {
        private Int32 accessoryID;
        private string description;
        private string name;
        private double price;
        private Int32 quantity;
        private string type;

        private clsDataConnection dBConnection = new clsDataConnection();

        public int AccessoryID { get => accessoryID; set => accessoryID = value; }
        public string Description { get => description; set => description = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Type { get => type; set => type = value; }

        public string Valid(string description, string name, string price, string quantity, string type) 
        {
            string ErrMsg = "";
            try
            {
                if (name.Length == 0)
                {
                    ErrMsg += "Name is blank\n";
                }
                if (description.Length == 0) 
                {
                    ErrMsg += "Description is blank\n";
                }
                if (type.Length == 0) 
                {
                    ErrMsg += "Type is blank\n";
                }
                double tempPrice;
                if (double.TryParse(price, out tempPrice) == false) 
                {
                    ErrMsg += "Price should only be in points\n";
                }
                int tempQuantity;
                if (int.TryParse(quantity, out tempQuantity)==false) 
                {
                    ErrMsg += "Please Input Valid Quantity\n";
                }
                return ErrMsg;
            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message;
            }
            return ErrMsg;
        }

        public Boolean Find(Int32 AccessoryID)
        {
            //initialise the DBConnection
            dBConnection = new clsDataConnection();
            //add the address no parameter
            dBConnection.AddParameter("@AccessoryID", AccessoryID);
            //execute the query
            dBConnection.Execute("sproc_tblAddress_FilterByAccessoryID");
            //if the record was found
            if (dBConnection.Count == 1)
            {
                //get the address no
                accessoryID = Convert.ToInt32(dBConnection.DataTable.Rows[0]["AccessoryID"]);
                //get the house no
                description = Convert.ToString(dBConnection.DataTable.Rows[0]["Description"]);
                //get the street
                name = Convert.ToString(dBConnection.DataTable.Rows[0]["Name"]);
                //get the town
                price = Convert.ToDouble(dBConnection.DataTable.Rows[0]["Price"]);
                //get the post code
                quantity = Convert.ToInt32(dBConnection.DataTable.Rows[0]["Quantity"]);
                //get the county code
                type = Convert.ToString(dBConnection.DataTable.Rows[0]["Type"]);
                //get the date added
                //return success
                return true;
            }
            else
            {
                //return failure
                return false;
            }
        }
    }
}