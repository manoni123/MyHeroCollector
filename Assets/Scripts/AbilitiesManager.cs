using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public Text playerLevelText, normalAttackText, specialAttackText, cooldownDecreaseText, PoisonSkillText, LightningSkillText, IceSkillText, GoldIncreaseText, TotalCP;
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
        int physicalTotal = player.attack + EnhanceSword() + EnhanceSwordPro() + MegaStrike() + EnergUnleash();
        int specialTotal = player.specialAttack + EnhancePunch() + MegaPunch();
        playerLevelText.text = "Player Level : " + player.level.ToString();
        normalAttackText.text = "Sword Attack : " + physicalTotal.ToString();
        specialAttackText.text = "Punch Attack : " + specialTotal.ToString();
        TotalCP.text = "Total CP: " + player.playerTotalCP.ToString();
        SkillsUpdate();
    }

    void SkillsUpdate()
    {
        if (player.SkillItemsId.Contains(5))
        {
            float iceChance = FreezePunch();
            IceSkillText.text = iceChance.ToString() + "% To Apply Freeze";
        }
        if (player.SkillItemsId.Contains(8))
        {
            PoisonSkillText.text = "Cuase " + PoisonBlade() + " Poison Every Second";
        }
        if (player.SkillItemsId.Contains(9))
        {
            LightningSkillText.text = "Cause " + LightningStrike() + " Lightning Damage";
        }
        if (player.SkillItemsId.Contains(10))
        {
            float CDDecrease = TimeBurst();
            cooldownDecreaseText.text = CDDecrease.ToString() + "% Punch Skill CD Reduction";
        }
        if (player.SkillItemsId.Contains(14) && player.SkillItemsId.Contains(16))
        {
            int goldPercent = GoldIncrease() + TreasurePool();
            GoldIncreaseText.text = goldPercent.ToString() + "% Gold Increase";
        }
        else if (player.SkillItemsId.Contains(14))
        {
            GoldIncreaseText.text = GoldIncrease().ToString() + "% Gold Increase";
        }
        else if (player.SkillItemsId.Contains(16))
        {
            GoldIncreaseText.text = TreasurePool().ToString() + "% Gold Increase";
        }
    }

    public int EnhancePunch()//increase player skill power
    {
        if (player.SkillItemsId.Contains(1))
        {
            int skillDamage = 5;
            return skillDamage;
        }
        return 0;
    }

    public int EnhanceSword()//increase player normal attack
    {
        if (player.SkillItemsId.Contains(2))
        {
            int skillDamage = 1;
            return skillDamage;
        }
        return 0;
    }
    public int MegaPunch()//firther increase plaer skill power
    {
        if (player.SkillItemsId.Contains(3))
        {
            int skillDamage = 10;
            return skillDamage;
        }
        return 0;
    }

    public int EnhanceSwordPro()//firther increase player power
    {
        if (player.SkillItemsId.Contains(4))
        {
            int skillDamage = 2;
            return skillDamage;
        }
        return 0;
    }
    public float FreezePunch()//Chance to cuase slow on target
    {
        if (player.SkillItemsId.Contains(5))
        {
            float slowPercent = 50;
            return slowPercent;
        }
        return 0;
    }
    public int MegaStrike()//firther increase  player power
    {
        if (player.SkillItemsId.Contains(6))
        {
            int skillDamage = 4;
            return skillDamage;
        }
        return 0;
    }
    public int ShieldStrike()//decerase damage taken by target
    {
        if (player.SkillItemsId.Contains(7))
        {
            int skillDamage = 25;
            return skillDamage;
        }
        return 0;
    }
    public int PoisonBlade()//Causes enemy poison status decrease health overtime.
    {
        if (player.SkillItemsId.Contains(8))
        {
            int skillDamage = 2;
            return skillDamage;
        }
        return 0;
    }
    public int LightningStrike()//A Chance to spawn lightning strike normal attack
    {
        if (player.SkillItemsId.Contains(9))
        {
            int skillDamage = 20;
            return skillDamage;
        }
        return 0;
    }
    public float TimeBurst()//decrease skill cooldown
    {
        if (player.SkillItemsId.Contains(10))
        {
            float skillDamage = 25;
            return skillDamage;
        }
        return 0;
    }
    public int JumpStart()//increase jump start number
    {
        if (player.SkillItemsId.Contains(11))
        {
            int skillDamage = 5;
            return skillDamage;
        }
        return 0;
    }
    public int EnergUnleash()//further increase player power
    {
        if (player.SkillItemsId.Contains(12))
        {
            int skillDamage = 10;
            return skillDamage;
        }
        return 0;
    }
    public float DropChance()//Increase Chance for rare items
    {
        if (player.SkillItemsId.Contains(13))
        {
            float dropIncrease = 5;
            return dropIncrease;
        }
        return 0;
    }
    public int GoldIncrease()//Increase Gold by 50%
    {
        if (player.SkillItemsId.Contains(14))
        {
            int skillDamage = 50;
            return skillDamage;
        }
        return 0;
    }
    public float DropChanceBetter()//Increase Chance for epic items
    {
        if (player.SkillItemsId.Contains(15))
        {
            float dropIncrease = 5;
            return dropIncrease;
        }
        return 0;
    }
    public int TreasurePool()//Increase Gold by another 50%
    {
        if (player.SkillItemsId.Contains(16))
        {
            int skillDamage = 50;
            return skillDamage;
        }
        return 0;
    }

}
