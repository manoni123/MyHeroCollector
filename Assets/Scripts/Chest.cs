using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Text chestText;
    public Player player;
    float currCountdownValue;
    float timeLeft = 2.0f;

    public void ChestOpen()
    {
        chestText.text = "You Win Chest, You got new item!";
        player.lastRandomNumber = calculateDropChance();
        StartCoroutine(StartCountdown());
    }

    public float calculateDropChance()
    {
        var rnd = Random.Range(0.0f, 100.0f);
        return rnd;
    }

    public IEnumerator StartCountdown(float countdownValue = 2)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            if (currCountdownValue == 0)
            {
                chestText.text = "";

            }
        }
    }
}
