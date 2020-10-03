using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public int itemID;
    public Player Player;

    void Start()
    {
        Player = FindObjectOfType<Player>();
        bool itemExist = Player.CollectionItemsId.Contains(itemID);

        if (!itemExist)
        {
            Player.CollectionItemsId.Add(itemID);
        }

        StartCoroutine("DestroyTimer");
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
