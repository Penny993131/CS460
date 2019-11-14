using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class StockItemDetailsViewModel(StockItem stockitem)
    {
        StockItemID = stockitem.StockItemID;
        StockItemName = stockitem.Name;
        StockItemSize = 
    }


public string StockItemName { get; private set; }
public decimal UnitPrice { get; private set; }
public string Size { get; private set; }
public decimal TypicalWeightPerUnit { get; private set; }
public int LeadTimeDays { get; private set; }
public DateTime ValidFrom { get; private set; }
public string Tags { get; private set; }




}