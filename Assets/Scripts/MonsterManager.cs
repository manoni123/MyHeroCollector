using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    Player player;
    Chest chest;
    SaveFile saveFile;
    public LootTable lootTable;
    public int monsterId;
    public float monsterHealth;
    public int healthRegen;
    public int chestId;
    public float dropChance;
    public bool isSpawn = false;
    Vector3 objectSpawn = new Vector3(0, 2.3f, 0);
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        chest = GameObject.Find("PlayerUI").GetComponent<Chest>();
        saveFile = FindObjectOfType<SaveFile>();
        player.scoreToNextLevel = monsterHealth;
    }
    void Update()
    {
        //show player score / next monster hp
        player.scoreText.text = player.score.ToString() + " / " + monsterHealth.ToString();

        if (player.score >= player.scoreToNextLevel && isSpawn)
        {
            Death();
        }
    }

    void Death()
    {
        {
            chest.GetComponent<Chest>().ChestOpen();
            MakeLoot();
            player.chestCount++;
            Destroy(gameObject);
            player.score = 0;
        }
    }

    private void MakeLoot()
    {
        Debug.Log("Loot function");

        if (lootTable != null)
        {
            GameObject current = lootTable.LootObject();
            if (current != null)
            {
                Debug.Log("should be dropped somthing");
                //instantiate an object and animate it towrds the same position + a fixed amount of random range from current transform
                Instantiate(current.gameObject, transform.position + objectSpawn, Quaternion.identity) ;
                chest.chestText.text = "You got big drop buddy!";
            }
        }
    }


}
