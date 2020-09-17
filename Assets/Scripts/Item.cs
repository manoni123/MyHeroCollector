using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public bool canShow;
    public int itemID;
    public float dropChance;
    public Player player;
    public Image silhouetteImage;

    void Update()
    {
        ShowUnlockedItems();
    }

    public void ShowUnlockedItems()
    {
        if (player.CollectionItemsId.Contains(itemID))
        {
            silhouetteImage.enabled = false;
        }
    }
}
