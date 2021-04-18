using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public bool collectionShown, settingShown, shopShown, leaderboardShown, abilityShown, restartShown, isCreditLayout, isSettingsLayout;
    public GameObject collectionWindow, settingWindow, shopWindow, leaderboardWindow, abilityWindow, restartWindow, settingsLayout, creditLayout;
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        collectionShown = false;
        shopShown = false;
        settingShown = false;
        leaderboardShown = false;
        abilityShown = false;
        restartShown = false;
        isCreditLayout = false;
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
            ShowSettingsLayout();
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

    public void ShowRestartWindow()
    {
        restartShown = !restartShown;
        if (restartShown)
        {
            restartWindow.SetActive(true);
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 0f;
        }
        else
        {
            restartWindow.SetActive(false);
            restartWindow.GetComponent<RestartManager>().defaultText.text = restartWindow.GetComponent<RestartManager>().defaultText.text;
            SoundManager.PlaySound("ClickEcho");
            Time.timeScale = 1f;
        }
    }

    public void ShowCreditLayout()
    {
        isCreditLayout = !isCreditLayout;
        if (isCreditLayout)
        {
            creditLayout.SetActive(true);
            settingsLayout.SetActive(false);
            isCreditLayout = false;
            SoundManager.PlaySound("ClickEcho");
        }
    }

    public void ShowSettingsLayout()
    {
        isSettingsLayout = !isSettingsLayout;
        if (isSettingsLayout)
        {
            settingsLayout.SetActive(true);
            creditLayout.SetActive(false);
            isSettingsLayout = false;
            SoundManager.PlaySound("ClickEcho");
        }
    }
}
