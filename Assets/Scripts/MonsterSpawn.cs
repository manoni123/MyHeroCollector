using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSpawn : MonoBehaviour
{
    Chest chest;
    public int mobCounter, skipPayment;
    public bool allowSpawn, fightStart = false;
    public Button[] guiButton;
    public Player player;
    public GameObject[] mobs;

    private void Start()
    {
        chest = GameObject.Find("PlayerUI").GetComponent<Chest>();
        player = GameObject.FindObjectOfType<Player>();
        skipPayment = 200;
    }

    private void Update()
    {
        if (fightStart)
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
                    if (mobCounter == (mobs.Length - 1))
                    {
                        mobCounter = 0;
                    }
                    else
                    {
                        mobCounter++;
                    }
                }
            }
        }
    }

    public void SkipMobs(GameObject Spawner)
    {
        if (player.gold >= skipPayment)
        {
            int remainingCount = mobs.Length - mobCounter;
            if (remainingCount > 10)
            {
                Destroy(Spawner.transform.GetChild(0).gameObject);
                GameObject nextMob = Instantiate(mobs[mobCounter + 10], transform.position, Quaternion.identity);
                nextMob.name = "currrentEnemy_" + mobCounter;
                nextMob.transform.SetParent(Spawner.transform);
                allowSpawn = false;
                nextMob.GetComponent<MonsterManager>().isSpawn = true;
                mobCounter += 10;
                player.score = 0;
                player.gold -= skipPayment;
                SoundManager.PlaySound("LevelUp");
            }
            else
            {
                chest.MainTextDisplay("You cannot skip level anymore");
            }
        }
        else
        {
            chest.MainTextDisplay("You do not have enough gold");
        }
    }

    public void StartSpawning(Button btn)
    {
        fightStart = true;
        btn.gameObject.SetActive(false); //the button activating this function
        for (int i = 0; i < guiButton.Length; i++)
        {
            guiButton[i].gameObject.SetActive(true);
        }
    }
}
