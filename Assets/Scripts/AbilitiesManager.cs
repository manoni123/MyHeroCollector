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
        int physicalTotal = player.attack + skillOne() + skillTwo();
        int specialTotal = player.specialAttack + skillThree();
        playerLevelText.text = "Player Level : " + player.level.ToString();
        normalAttackText.text = "Physical Attack : " + physicalTotal.ToString();
        specialAttackText.text = "Special Attack : "+ specialTotal.ToString();
        cooldownDecreaseText.text = "Cooldown Decrease : " + player.cooldownDecrease.ToString();
        DoubleStrikeText.text = "Double Strike Chance : " + player.doubleStrike.ToString();
    }

    public int skillOne()
    {
        if (player.SkillItemsId.Contains(1))
        {
            int skillDamage = 10;
            return skillDamage;
        }
        return 0;
    }

    public int skillTwo()
    {
        if (player.SkillItemsId.Contains(2))
        {
            int skillDamage = 10;
            return skillDamage;
        }
        return 0;
    }
    public int skillThree()
    {
        if (player.SkillItemsId.Contains(3))
        {
            int skillDamage = 10;
            return skillDamage;
        }
        return 0;
    }


}
