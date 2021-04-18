using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public PausePanel panel;
    public MonsterSpawn spawnManager;
    public GameObject[] dialogues;
    public bool showDialogue = false;
    public bool hideGUI;

    // Update is called once per frame

    void Update()
    {
        ShowDialogues();
        StartSceneDialogue();
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
                Time.timeScale = 0f;

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
                Time.timeScale = 0f;

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
                Time.timeScale = 0f;

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
                Time.timeScale = 0f;

            }
            else
            {
                Destroy(dialogues[5]);

            }
        }
    }

    void StartSceneDialogue()
    {
        if (!player.StartScene)
        {
            Time.timeScale = 0;
            if (!player.DialogueProgress.Contains(6))
            {
                dialogues[6].SetActive(true);
            }
            if (player.DialogueProgress.Contains(6) && !player.DialogueProgress.Contains(7))
            {
                dialogues[7].SetActive(true);
            }
            if (player.DialogueProgress.Contains(7) && !player.DialogueProgress.Contains(8))
            {
                dialogues[8].SetActive(true);
            }
            if (player.DialogueProgress.Contains(8) && !player.DialogueProgress.Contains(9))
            {
                dialogues[9].SetActive(true);
            }
        }
        else
        {
            Destroy(dialogues[6]);
            Destroy(dialogues[7]);
            Destroy(dialogues[8]);
            Destroy(dialogues[9]);
        }
    }
}
