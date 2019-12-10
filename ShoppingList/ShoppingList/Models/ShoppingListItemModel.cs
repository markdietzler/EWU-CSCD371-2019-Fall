using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Models
{
    public class ShoppingListItemModel
    {
        public string ItemName { get; set; }

        public ShoppingListItemModel(string listItem)
        {
            ItemName = listItem;
        }
    }
}
