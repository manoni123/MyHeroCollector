using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSpawn : MonoBehaviour
{
    Chest chest;
    public int mobCounter, skipPayment, skipCount, restartPayment;
    public bool allowSpawn, fightStart = false, skipCountIncrease = false, soundPlayed = false;
    public Player player;
    public Text RestartPanelText;
    public PausePanel RestartPanel;
    Vector3 spawnMobPos;
    public float spawnDecendSpeed;
    public GameObject[] guiButton;
    public GameObject[] mobs;
    GameObject nextMob;

    private void Start()
    {
        chest = GameObject.Find("PlayerUI").GetComponent<Chest>();
        player = FindObjectOfType<Player>();
        restartPayment = 100;
        skipPayment = 200;
    }

    private void Update()
    {
        if (fightStart)
        {
            if (!soundPlayed)
            {
                SoundManager.PlaySound("Adventure");
                soundPlayed = true;
            }
            if (transform.childCount == 0)
            {
                allowSpawn = true;
                if (allowSpawn)
                {
                    spawnMobPos = new Vector3(0.0f, 1f);
                    nextMob = Instantiate(mobs[mobCounter], spawnMobPos, Quaternion.identity);
                    nextMob.name = "currrentEnemy_" + mobCounter;
                    nextMob.transform.SetParent(transform);
                    allowSpawn = false;
                    nextMob.GetComponent<MonsterManager>().isSpawn = true;
                    if (mobCounter == (mobs.Length - 1)) //restart mobs when reaching final monster
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
        //update the mob position to initial position to show decend effect
        if (fightStart)
        {
            nextMob.transform.position = Vector3.MoveTowards(nextMob.transform.position, transform.position, spawnDecendSpeed * Time.deltaTime); 
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
                    nextMob = Instantiate(mobs[mobCounter + skipCount], spawnMobPos, Quaternion.identity);
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
    public void RestartMonsters(GameObject Spawner)
    {
        if (player.gold >= restartPayment)
        {
            Destroy(Spawner.transform.GetChild(0).gameObject);
            nextMob = Instantiate(mobs[0], transform.position, Quaternion.identity);
            nextMob.name = "currrentEnemy_" + mobCounter;
            nextMob.transform.SetParent(Spawner.transform);
            allowSpawn = false;
            nextMob.GetComponent<MonsterManager>().isSpawn = true;
            mobCounter = 0;
            player.score = 0;
            player.gold -= restartPayment;
            SoundManager.PlaySound("LevelUp");
            RestartPanel.ShowRestartWindow();
        }
        else
        {
            RestartPanelText.text = "You do not have enough gold... how shame :O";
        }
    }
}
