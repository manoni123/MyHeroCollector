using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public Text playerLevelText, normalAttackText, specialAttackText, cooldownDecreaseText, DoubleStrikeText;
    [Header("Skill Deatails")]
    public Text skillName;
    public Text skillDesc;
    public Text skillCost;
    public Text skillGemCost;
    public int skillID;
    public GameObject[] DetailsInfo;

    // Update is called once per frame
    void Update()
    {
        playerLevelText.text = "Player Level : " + player.level.ToString();
        normalAttackText.text = "Physical Attack : " + player.attack.ToString();
        specialAttackText.text = "Special Attack : "+ player.specialAttack.ToString();
        cooldownDecreaseText.text = "Cooldown Decrease : " + player.cooldownDecrease.ToString();
        DoubleStrikeText.text = "Double Strike Chance : " + player.doubleStrike.ToString();
    }
}
