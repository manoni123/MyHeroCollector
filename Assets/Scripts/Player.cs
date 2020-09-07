using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class Player : MonoBehaviour
{
    public float score, scoreToNextLevel;
    public int chestCount, level, attack, specialAttack, gold, diamond;
    public float skillTimer, cooldownDecrease, doubleStrike;
    public float lastRandomNumber = 0.01f;
    public bool skillReady, allowReset = false;
    public Text scoreText, goldText, diamondText;
    public Image scoreImage, skillCooldownImage;
    public Chest chest;

    [Header("Collection List")]
    public List<int> CollectionItemsId = new List<int>();

    [Header("Skill List")]
    public List<int> SkillItemsId = new List<int>();

    // Use this for initialization
    void Start()
    {
        skillReady = true;
        chest = FindObjectOfType<Chest>();
    }

    // Update is called once per frame
    void Update()
    {
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
        score = score + attack;        
    }
    public void increaseScoreBySkill()
    {
        if (skillReady)
        {
            skillCooldownImage.fillAmount = 1f;
            score = score + specialAttack;
            skillReady = false;
            StartCoroutine("skillCooldown");
        }
    }

    IEnumerator skillCooldown()
    {
        yield return new WaitForSeconds(skillTimer);
        skillReady = true;
    }
}
