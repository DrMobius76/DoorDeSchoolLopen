using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    private Item item;  

    
    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    
    
}
