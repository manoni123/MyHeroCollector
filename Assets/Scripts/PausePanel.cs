using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    private bool collectionShown, settingShown, shopShown, leaderboardShown, abilityShown;
    public GameObject collectionWindow, settingWindow, shopWindow, leaderboardWindow, abilityWindow;
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        collectionShown = false;
        shopShown = false;
        settingShown = false;
        leaderboardShown = false;
        abilityShown = false;
    }

    public void ShowCollection()
    {
        collectionShown = !collectionShown;
        if (collectionShown)
        {
            collectionWindow.SetActive(true);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 0f;

        }
        else
        {
            collectionWindow.SetActive(false);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 1f;
        }
    }

    public void ShowShop()
    {
        shopShown = !shopShown;
        if (shopShown)
        {
            shopWindow.SetActive(true);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 0f;
        }
        else
        {
            shopWindow.SetActive(false);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 1f;
        }
    }

    public void ShowSetting()
    {
        settingShown = !settingShown;
        if (settingShown)
        {
            settingWindow.SetActive(true);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 0f;
        }
        else
        {
            settingWindow.SetActive(false);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 1f;
        }
    }

    public void ShowLeaderboard()
    {
        leaderboardShown = !leaderboardShown;
        if (leaderboardShown)
        {
            leaderboardWindow.SetActive(true);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 0f;
        }
        else
        {
            leaderboardWindow.SetActive(false);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 1f;
        }
    }

    public void ShowAbility()
    {
        abilityShown = !abilityShown;
        if (abilityShown)
        {
            abilityWindow.SetActive(true);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 0f;
        }
        else
        {
            abilityWindow.SetActive(false);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 1f;
        }
    }
}
