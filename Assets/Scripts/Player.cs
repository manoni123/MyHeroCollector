using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class Player : MonoBehaviour
{
    public float level, score, scoreToNextLevel;
    public int chestCount;
    public float skillTimer;
    public float lastRandomNumber = 0.01f;
    public bool skillReady, allowReset = false;
    public Text scoreText;
    public Image scoreImage, skillCooldownImage;
    public Chest chest;

    [Header("Collection List")]
    public List<int> CollectionItemsId = new List<int>();

    // Use this for initialization
    void Start()
    {
        level = 1;
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
        ScoreBarReset();
    }

    void ScoreBarReset()
    {
        scoreImage.fillAmount = score / scoreToNextLevel;
    }

    public void increaseScoreByWeapon()
    {
        score = score + 1;        
    }
    public void increaseScoreBySkill()
    {
        if (skillReady)
        {
            skillCooldownImage.fillAmount = 1f;
            score = score + 5;
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
