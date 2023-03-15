using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> itemList = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots;



    // Start is called before the first frame update
    void Awake()
    {
        for(int i=0; i < numberOfSlots; i++) {
            GameObject slotInstance = Instantiate(slotPrefab);

            //set the slot INSIDE the slot panel
            slotInstance.transform.SetParent(slotPanel);

            //put the instances in the LIST, a LIST of UIItem components

            itemList.Add(slotInstance.GetComponentInChildren<UIItem>());

        }
        
        
    }

    public void UpdateSlot(int slot, Item item) {

        //how is this calling that function??????
        itemList[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item) {
        //find which itemList index is empty and put an item into it
        //and UPDATE SLOT ( parameters: slot number, item)
        UpdateSlot(itemList.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item) {
        UpdateSlot(itemList.FindIndex(i => i.item == item), null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
