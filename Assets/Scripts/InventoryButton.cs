using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject Inventory;
    public Action<InventoryButton> ActivateInventory;
    public void OnPointerClick(PointerEventData eventData)
    {
        ActivateInventory(this);
    }
}
