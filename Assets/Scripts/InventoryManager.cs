using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<InventoryButton> ListInventory;

    private void OnEnable()
    {
        foreach (InventoryButton go in ListInventory)
        {
            go.ActivateInventory += OnActivateInventory;
        }

        // ListInventory[0].Inventory.SetActive(true);
    }

    private void OnActivateInventory(GameObject intventory)
    {
        foreach (InventoryButton go in ListInventory)
        {
            go.Inventory.SetActive(false);
        }

        intventory.SetActive(true);
    }

    private void OnDisable()
    {
        foreach (InventoryButton go in ListInventory)
        {
            go.ActivateInventory -= OnActivateInventory;
        }
    }
}
