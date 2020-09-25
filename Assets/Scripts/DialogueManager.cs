using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public PausePanel panel;
    public MonsterSpawn spawnManager;
    public Transform middlePos;
    public GameObject[] dialogues;
    public bool showDialogue = false;

    // Update is called once per frame

    void Update()
    {
        ShowDialogues();
    }

    void ShowDialogues()
    {
        if (panel.abilityShown && !showDialogue)
        {
            if (!player.DialogueProgress.Contains(0))
            {
                dialogues[0].SetActive(true);
            }
            else
            {
                Destroy(dialogues[0]);
            }
        }

        if (panel.collectionShown && !showDialogue)
        {
            if (!player.DialogueProgress.Contains(1))
            {
                dialogues[1].SetActive(true);
            }
            else
            {
                Destroy(dialogues[1]);
            }
        }

        if (spawnManager.fightStart)
        {
            if (!player.DialogueProgress.Contains(2))
            {
                dialogues[2].SetActive(true);
                dialogues[2].transform.position = middlePos.position;
            }
            else
            {
                Destroy(dialogues[2]);
            }
        }

        if (player.monsterKillRecord >= 5)
        {
            if (!player.DialogueProgress.Contains(3))
            {
                dialogues[3].SetActive(true);
                dialogues[3].transform.position = middlePos.position;
            }
            else
            {
                Destroy(dialogues[3]);
            }
        }

        if (player.monsterKillRecord >= 8)
        {
            if (!player.DialogueProgress.Contains(4))
            {
                dialogues[4].SetActive(true);
                dialogues[4].transform.position = middlePos.position;
            }
            else
            {
                Destroy(dialogues[4]);
            }
        }

        if (player.CollectionItemsId.Count >= 20)
        {
            if (!player.DialogueProgress.Contains(5))
            {
                dialogues[5].SetActive(true);
                dialogues[5].transform.position = middlePos.position;
            }
            else
            {
                Destroy(dialogues[5]);
            }
        }
    }
}
