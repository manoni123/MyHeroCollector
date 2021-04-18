using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartManager : MonoBehaviour
{
    public Player player;
    public Text defaultText;
    public MonsterSpawn spawnManager;
    public string requiredPayment;
    public bool hasEnoughGold;
    // Start is called before the first frame update

    public void Update()
    {
        defaultText.text = "Are you sure you want to return to monster level 1 ? The cost is : " + spawnManager.restartPayment + " Gold.";
    }
}
