using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] inventoryItems;

    public GameObject Inventory;

    private void Awake()
    {
        Instance = this; 
    }

    private void Update()
    {
        // Controleer of de I-toets wordt ingedrukt om de inventory te toggelen
        if (Input.GetKeyDown(KeyCode.J))
        {
                ActivateInventory();
        }


    }

    public void ActivateInventory()
    {
        
           
            bool isActive = !Inventory.activeSelf; // Bepaal of de inventory nu actief moet worden
            ListItems();
            Inventory.SetActive(isActive); // Wissel de actieve status van de inventory

            // Pauze de game of hervat deze
            if (isActive)
            {
                Cursor.lockState = CursorLockMode.None; // Ontgrendel de muis
                Cursor.visible = true; // Maak de muis zichtbaar
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked; // Lock de muis naar het midden
                Cursor.visible = false; // Maak de muis onzichtbaar
            }

            
        
    }

    public void Add(Item item)
    {
        items.Add(item);
    }
 

    public void ListItems()
    {
        // Verwijder bestaande UI-items
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        // Doorloop alle items in de lijst en toon ze in de UI
        //hier zitten de problemen
        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var controller = obj.GetComponent<InventoryItemController>(); // Verkrijg de InventoryItemController 

            // Stel het item in
            controller.AddItem(item);

            var itemNameTransform = obj.transform.Find("ItemName");
            var itemIconTransform = obj.transform.Find("ItemIcon");

            var itemName = itemNameTransform.GetComponent<TextMeshProUGUI>();
            var itemIcon = itemIconTransform.GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            
        }

        SetInventoryItems(); // Update de lijst van inventory items in de UI
    }


    

    public void SetInventoryItems()
    {
        inventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
    
        for(int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }


    }

