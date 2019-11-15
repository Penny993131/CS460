using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;


namespace HW6.Models.ViewModels
{
    public class StockItemDetailsViewModel
    {
        public StockItemDetailsViewModel(StockItem stockitem)
        {
            StockItemID = stockitem.StockItemID;
            StockItemName = stockitem.StockItemName;
            Size = stockitem.Size;
           string tempCustomFields = stockitem.CustomFields;
            JObject jason = JObject.Parse(tempCustomFields);
            Origin = (string)jason["CountryOfManufacture"];
            RecommendedRetailPrice = stockitem.RecommendedRetailPrice;
            TypicalWeightPerUnit = stockitem.TypicalWeightPerUnit;
            LeadTimeDays = stockitem.LeadTimeDays;
            ValidFrom = stockitem.ValidFrom;
            Tags = stockitem.Tags;
            Photo = stockitem.Photo;
            string company = stockitem.Supplier.SupplierName;
            SupplierName = company;
            string phone = stockitem.Supplier.PhoneNumber;
            PhoneNumber = phone;
            string fax = stockitem.Supplier.FaxNumber;
            FaxNumber = fax;
            string website = stockitem.Supplier.WebsiteURL;
            WebsiteURL = website;
            string contactperson = stockitem.Supplier.Person2.FullName;
            Contact = contactperson;
            InvoiceLines = stockitem.InvoiceLines.Count();
            //GrossSales;
            ExtendedPrice = stockitem.InvoiceLines.Select(x => x.ExtendedPrice).Sum();
            //GrossProfis 
            LineProfit = stockitem.InvoiceLines.Select(x => x.LineProfit).Sum();
           





        }
        public int StockItemID { get; private set; }
        public string StockItemName { get; private set; }
        public decimal? RecommendedRetailPrice { get; private set; }
        public string Size { get; private set; }
        public string Origin { get; private set; }
        public decimal TypicalWeightPerUnit { get; private set; }
        public int LeadTimeDays { get; private set; }
        public DateTime ValidFrom { get; private set; }
        public string Tags { get; private set; }
        public byte[] Photo { get; private set; }
        public string SupplierName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string FaxNumber { get; private set; }
        public string WebsiteURL { get; private set; }
        public string Contact { get; private set; }
        public DbGeography DeliveryLocation { get; private set; }
        public Supplier Supplier { get; private set; }
        public int InvoiceLines { get; private set; }
        public decimal ExtendedPrice {  get; private set; }
        public decimal LineProfit { get; private set; }

        

    }






}