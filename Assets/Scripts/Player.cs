using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class Player : MonoBehaviour
{
    public float score, scoreToNextLevel;
    public int chestCount, level, attack, specialAttack, gold, diamond, skipForward;
    public float skillTimer, cooldownDecrease, doubleStrike;
    public float lastRandomNumber = 0.01f;
    public bool skillReady, allowReset = false, normalAttackEffect, specialAttackEffect, usedSkill, isPoisoned, CDSkillActivated = false;
    public Text scoreText, goldText, diamondText, skipForwardText;
    public Image scoreImage, skillCooldownImage;
    public Chest chest;
    public AbilitiesManager abilitiesManager;

    [Header("Collection List")]
    public List<int> CollectionItemsId = new List<int>();

    [Header("Skill List")]
    public List<int> SkillItemsId = new List<int>();

    // Use this for initialization
    void Start()
    {
        attack = 1;
        specialAttack = 5;
        diamond = 500;
        skillReady = true;
        chest = FindObjectOfType<Chest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SkillItemsId.Contains(10) && !CDSkillActivated)
        {
            skillTimer -= skillTimer * (abilitiesManager.TimeBurst() / 100);
            CDSkillActivated = true;
        }

        if (!skillReady)
        {
            skillCooldownImage.fillAmount -= 1.0f / skillTimer * Time.deltaTime;
        }

        goldText.text = gold.ToString();
        diamondText.text = diamond.ToString();

        ScoreBarReset();
        preventMinusScore();
    }

    void preventMinusScore()
    {
        if (score <= 0)
        {
            score = 0;
        }
    }

    void ScoreBarReset()
    {
        scoreImage.fillAmount = score / scoreToNextLevel;
    }

    public void increaseScoreByWeapon()
    {
        int totalDamage = attack + abilitiesManager.EnhanceSword() + abilitiesManager.EnhanceSwordPro() + abilitiesManager.MegaStrike() + abilitiesManager.EnergUnleash();
        score += totalDamage;
        normalAttackEffect = true;
    }
    public void increaseScoreBySkill()
    {
        int totalDamage = specialAttack + abilitiesManager.EnhancePunch() + abilitiesManager.MegaPunch();
        usedSkill = true;
        if (skillReady)
        {
            skillCooldownImage.fillAmount = 1f;
            score +=  totalDamage;
            skillReady = false;
            specialAttackEffect = true;
            StartCoroutine("skillCooldown");
        }
    }

    IEnumerator skillCooldown()
    {
        yield return new WaitForSeconds(skillTimer);
        skillReady = true;
    }
}
