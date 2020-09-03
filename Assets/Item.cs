using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public bool canShow;
    public int itemID;
    public Player player;
    public Image silhouetteImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowUnlockedItems();
    }

    public void ShowUnlockedItems()
    {
        if (player.chestCount >= 1)
        {
            if (itemID == 1)
            {
                silhouetteImage.enabled = false;
            }
        }
        if (player.chestCount >= 3)
        {
            if (itemID == 3)
            {
                silhouetteImage.enabled = false;
            }
        }
    }
}
