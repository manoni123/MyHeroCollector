using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartManager : MonoBehaviour
{
    public Player player;
    public Text RestartText;
    public string originText;
    public bool startText;
    public int requiredPayment;
    // Start is called before the first frame update
    void Start()
    {
        requiredPayment = 100;
        originText = "Are you sure you want to return to monster level 1 ? cost of : " + requiredPayment + " Gold";
        RestartText.text = originText;
    }
}
