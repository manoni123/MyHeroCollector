using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Text chestText;
    public Player player;
    float currCountdownValue;

    public void MainTextDisplay(string text)
    {
        chestText.text = text;
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
            yield return new WaitForSeconds(0.75f);
            currCountdownValue--;
            if (currCountdownValue == 0)
            {
                chestText.text = "";

            }
        }
    }
}
