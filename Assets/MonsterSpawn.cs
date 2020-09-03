using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public int mobCounter;
    public bool allowSpawn;
    public Player player;
    public GameObject[] mobs;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            allowSpawn = true;
            if (allowSpawn)
            {
                GameObject nextMob = Instantiate(mobs[mobCounter], transform.position, Quaternion.identity);
                nextMob.name = "currrentEnemy_" + mobCounter;
                nextMob.transform.SetParent(transform);
                allowSpawn = false;
                nextMob.GetComponent<MonsterManager>().isSpawn = true;
                mobCounter++;
            }
        }
    }
}
