using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KitchenInventoryManager : MonoBehaviour
{
    [SerializeField] private List<InventoryButton> ListInventory;
    [SerializeField] private GameObject Backpack;
    [SerializeField] private TextMeshProUGUI TextUP;
    private List<string> NameInventory = new List<string> { "Ящик 1", "Ящик 2", "Ящик 3", "Ящик 4", "Ящик 5" };

    private void OnEnable()
    {
        foreach (InventoryButton go in ListInventory)
        {
            go.ActivateInventory += OnActivateInventory;
        }

        Backpack.gameObject.SetActive(true);

        ListInventory[0].Inventory.SetActive(true);
        TextUP.text = NameInventory[0];
    }

    private void OnActivateInventory(InventoryButton button)
    {
        foreach (InventoryButton go in ListInventory)
        {
            go.Inventory.SetActive(false);
        }

        var index = ListInventory.IndexOf(button);
        TextUP.text = NameInventory[index];

        button.Inventory.SetActive(true);
    }

    private void OnDisable()
    {
        Backpack.gameObject.SetActive(false);

        foreach (InventoryButton go in ListInventory)
        {
            go.ActivateInventory -= OnActivateInventory;
            go.Inventory.SetActive(false);
        }
    }
}
