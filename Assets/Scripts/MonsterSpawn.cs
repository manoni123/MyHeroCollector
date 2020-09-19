using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSpawn : MonoBehaviour
{
    Chest chest;
    public int mobCounter, skipPayment, skipCount;
    public bool allowSpawn, fightStart = false, skipCountIncrease = false;
    public GameObject[] guiButton;
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
        if (player.SkillItemsId.Contains(11))
        {
            if (!skipCountIncrease)
            {
                skipCount += player.abilitiesManager.JumpStart();
                skipCountIncrease = true;
            }
        }

        guiButton[3].gameObject.GetComponentInChildren<Text>().text = skipCount.ToString(); //skip number can be updated by skill
    }

    public void SkipMobs(GameObject Spawner)
    {
        if (skipCount >= 5)
        {
            if (player.gold >= skipPayment)
            {
                int remainingCount = mobs.Length - mobCounter;
                if (remainingCount > skipCount)
                {
                    Destroy(Spawner.transform.GetChild(0).gameObject);
                    GameObject nextMob = Instantiate(mobs[mobCounter + skipCount], transform.position, Quaternion.identity);
                    nextMob.name = "currrentEnemy_" + mobCounter;
                    nextMob.transform.SetParent(Spawner.transform);
                    allowSpawn = false;
                    nextMob.GetComponent<MonsterManager>().isSpawn = true;
                    mobCounter += skipCount;
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
