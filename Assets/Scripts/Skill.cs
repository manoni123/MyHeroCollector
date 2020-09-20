using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    public string skillName, skillDescription, ownedSkill;
    public int skillID,skillGoldCost, skillDiamondCost;
    public AbilitiesManager abilitiesManager;
    public Player player;

    public void ClickOnSkill()
    {
        ownedSkill = skillDescription + " - You Own This Skill";
        SoundManager.PlaySound("Click");
        abilitiesManager.DetailsInfo[0].SetActive(true);
        abilitiesManager.DetailsInfo[1].SetActive(true);
        if (!player.SkillItemsId.Contains(skillID))
        {
            //if skill ID already on player skill list = dont show button to buy
            abilitiesManager.DetailsInfo[2].SetActive(true);
            abilitiesManager.skillDesc.text = skillDescription;
        }
        else if (player.SkillItemsId.Contains(skillID))
        {
            abilitiesManager.DetailsInfo[2].SetActive(false);
            abilitiesManager.skillDesc.text = ownedSkill;
        }
        abilitiesManager.skillID = skillID;
        abilitiesManager.skillName.text = skillName;
       // abilitiesManager.skillDesc.text = skillDescription;
        abilitiesManager.skillCost.text = skillGoldCost.ToString();
        abilitiesManager.skillGemCost.text = skillDiamondCost.ToString();
    }

    public void BuySkill()
    {
        int goldCost = Int32.Parse(abilitiesManager.skillCost.text);
        int diamondCost = Int32.Parse(abilitiesManager.skillGemCost.text);
        int skillId = abilitiesManager.skillID;
        if (player.SkillItemsId.Contains(skillId))
        {
            SoundManager.PlaySound("Click");
            abilitiesManager.skillDesc.text = "You already own this ability, do you need some rest?";
        }
        else
        {
            if (player.gold >= goldCost && player.diamond >= diamondCost)
            {
                player.gold -= goldCost;
                player.diamond -= diamondCost;
                player.SkillItemsId.Add(skillId);
                abilitiesManager.DetailsInfo[2].SetActive(false);
                SoundManager.PlaySound("LevelUp");
                abilitiesManager.skillDesc.text = "You seem stronger! make good use of the ability";
            }
            else
            {
                abilitiesManager.skillDesc.text = "You do not have enough coins... how shame";
            }
        }
    }
 
}
