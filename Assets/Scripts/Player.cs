using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class Player : MonoBehaviour
{
    public float score, scoreToNextLevel, playerExp, goalExp;
    public int chestCount, level, attack, specialAttack, gold, diamond, skipForward, monsterKillRecord, playerTotalCP;
    public float skillTimer, cooldownDecrease, doubleStrike;
    public float lastRandomNumber = 0.01f;
    public bool skillReady, allowReset = false, normalAttackEffect, specialAttackEffect, usedSkill, isPoisoned, CDSkillActivated = false, StartScene = false;
    public Text scoreText, goldText, diamondText, skipForwardText, playerExpText, levelText;
    public Image scoreImage, skillCooldownImage, expProrgessImage;
    public Chest chest;
    public AbilitiesManager abilitiesManager;

    [Header("Collection List")]
    public List<int> CollectionItemsId = new List<int>();

    [Header("Skill List")]
    public List<int> SkillItemsId = new List<int>();

    [Header("Progress List")]
    public List<int> DialogueProgress = new List<int>(); 

    // Use this for initialization
    void Start()
    {
        attack = 1;
        specialAttack = 5;
        skillReady = true;
        chest = FindObjectOfType<Chest>();
        Debug.Log(Application.persistentDataPath + "  " + Application.dataPath);
    }

    // Update is called once per frame
    void Update()
    {
        int goalExpConvert = (int)goalExp;
        goldText.text = gold.ToString();
        diamondText.text = diamond.ToString();
        playerExpText.text = playerExp.ToString() + " / " + goalExpConvert.ToString();
        levelText.text = "Lv." + level.ToString();

        if (SkillItemsId.Contains(10) && !CDSkillActivated)
        {
            skillTimer -= skillTimer * (abilitiesManager.TimeBurst() / 100);
            CDSkillActivated = true;
        }

        if (!skillReady)
        {
            skillCooldownImage.fillAmount -= 1.0f / skillTimer * Time.deltaTime;
        }

        if (playerExp >= goalExp)
        {
            LevelUp();
        }

        PlayerExpProgress();
        ScoreBarReset();
        preventMinusScore();
        PlayerTotalCP();
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

    void PlayerExpProgress()
    {
        expProrgessImage.fillAmount = playerExp / goalExp;
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

    public void LevelUp()
    {
        level++;
        playerExp = 0;
        goalExp = goalExp * 1.5f;
        CloudOneServices.instance.SubmitScoreToLeaderboard(playerTotalCP);
    }

    public void PlayerTotalCP()
    {
        playerTotalCP = (SkillItemsId.Count * 3) + (CollectionItemsId.Count + monsterKillRecord) * level;
        CloudOnce.Leaderboards.HighScore.SubmitScore(playerTotalCP);
    }

    public void SaveWhenUpdate()
    {
        CloudOnce.CloudVariables.PlayerGold = gold;
        CloudOnce.CloudVariables.PlayerDiamond = diamond;
        CloudOnce.Cloud.Storage.Save();
    }
}
