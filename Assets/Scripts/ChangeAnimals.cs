using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeAnimals : MonoBehaviour, IPointerClickHandler
{
    public List<Sprite> ListSpriteAnimals;
    public Image Image;
    private int i = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        i++;
        Image.sprite = ListSpriteAnimals[Next(i)];
    }

    private int Next(int currentPageIndex)
    {
        Debug.Log((currentPageIndex + 1) % (ListSpriteAnimals.Count));

        return (currentPageIndex + 1) % (ListSpriteAnimals.Count);
    }

    private int Previous(int currentPageIndex)
    {
        Debug.Log((currentPageIndex + ListSpriteAnimals.Count - 1) % ListSpriteAnimals.Count);

        return (currentPageIndex + ListSpriteAnimals.Count - 1) % ListSpriteAnimals.Count;
    }
}
