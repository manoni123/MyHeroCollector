using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    Player player;
    Chest chest;
    SaveFile saveFile;
    public LootTable lootTable;
    public int monsterId, monsterLevel;
    public float monsterHealth;
    public float monsterDamageCooldown;
    public int chestId;
    public int goldDrop;
    public bool isSpawn = false, isBoss, isPoisoned;
    public GameObject[] Effects;
    Vector3 objectSpawn = new Vector3(0, 2.3f, 0);
    /// <summary>Effects explain
    /// #0 = damage by normal attack
    /// #1 = damage by skill
    /// #2 = attack player w/ projectile
    /// #3 = poison skill applied
    /// #4 = lightning effect
    /// #5 = ice effect applid
    /// </summary>
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        chest = GameObject.Find("PlayerUI").GetComponent<Chest>();
        saveFile = FindObjectOfType<SaveFile>();
        player.scoreToNextLevel = monsterHealth;
        InvokeRepeating("DamagePlayer", 2f, monsterDamageCooldown);

        if (isBoss)
        {
            player.scoreImage.color = Color.red;
        }
        else if (!isBoss)
        {
            player.scoreImage.color = new Color(69f/255f,130f/255f,179f/255f);
        }
    }
    void Update()
    {
        //show player score / next monster hp
        if (isBoss)
        {
            player.scoreText.text ="Boss!     " + player.score.ToString() + " / " + monsterHealth.ToString();
        }
        else
        {
            player.scoreText.text = "Lv. " + monsterLevel + "       " + player.score.ToString() + " / " + monsterHealth.ToString();
        }

        MonsterEffects();

        //bite off players score every some time
        if (player.score >= player.scoreToNextLevel && isSpawn)
        {
            Death();
        }
    }

    void DamagePlayer()
    {
        //hit player every X seconds with invoke
        Vector3 shootingPos = new Vector3(0.0f, -1.0f);
        Instantiate(Effects[2], transform.position + shootingPos, Quaternion.identity);
        if (player.SkillItemsId.Contains(7))
        {
            int damageplayer;
            damageplayer = monsterLevel - (player.abilitiesManager.ShieldStrike() / 100);
            player.score -= damageplayer;
        }
        else
        {
            player.score -= monsterLevel;
        }
    }

    void MonsterEffects()
    {
        //all effect casued on mob will start here
        if (player.normalAttackEffect)
        {
            Instantiate(Effects[0], transform.position, Quaternion.identity);
            InitiatePoison();
            LightningSkill();
            player.normalAttackEffect = false;
        }
        if (player.specialAttackEffect)
        {
            Instantiate(Effects[1], transform.position, Quaternion.identity);
            IceSkill();
            player.specialAttackEffect = false;
        }
    }

    void Death()
    {
        {
         //   chest.GetComponent<Chest>().MainTextDisplay();
            CancelInvoke("DamagePlayer");
            player.chestCount++;
            MakeLoot();
            GoldDropped();
            player.usedSkill = false;
            isPoisoned = false;
            Destroy(gameObject);
            player.score = 0;
            player.level++;
        }
    }
    void GoldDropped()
    {
        int goldBySkills = 0;
        if (player.SkillItemsId.Contains(14) && player.SkillItemsId.Contains(16))
        {
            goldBySkills = goldDrop * ((player.abilitiesManager.GoldIncrease() + player.abilitiesManager.TreasurePool()) / 100);
        }
        else if(player.SkillItemsId.Contains(14))
        {
            goldBySkills = goldDrop * player.abilitiesManager.GoldIncrease() / 100;
        }
        else if (player.SkillItemsId.Contains(16))
        {
            goldBySkills = goldDrop * player.abilitiesManager.TreasurePool() / 100;
        }
        goldDrop += goldBySkills;
        int sum = (monsterLevel * goldDrop) + (player.level * 2);
        Debug.Log("mob gold is: " + sum);
        player.gold += sum;
    }

    private void MakeLoot()
    {
        if (lootTable != null)
        {
            GameObject current = lootTable.LootObject();
            if (current != null)
            {
                Debug.Log("should be dropped somthing");
                Instantiate(current.gameObject, transform.position + objectSpawn, Quaternion.identity) ;
                chest.MainTextDisplay("You Found A : " + current.gameObject.name);
            }
        }
    }
    void InitiatePoison()//check plater has skill, if so, calc chance, if so = posioned invoke
    {
        if (player.SkillItemsId.Contains(8))
        {
            float chance = Random.Range(0, 100);
            if (chance >= 75f)
            {
                isPoisoned = true;
                if (isPoisoned)
                {
                    Instantiate(Effects[3], transform.position, Quaternion.identity);
                    InvokeRepeating("PoisonSkillDamage", 2f, 1f);
                }
            }
        }
    }

    void PoisonSkillDamage()
    {
        player.score += player.abilitiesManager.PoisonBlade();
    }

    void LightningSkill()
    {
        if (player.SkillItemsId.Contains(9))
        {
            float chance = Random.Range(0, 100);
            if (chance >= 90f)
            {
                Instantiate(Effects[4], transform.position, Quaternion.identity);
                player.score += player.abilitiesManager.LightningStrike(); ;
            }

        }
    }

    void IceSkill()
    {
        if (player.SkillItemsId.Contains(5))
        {
            float chance = Random.Range(0, 100);
            if (chance > 50f)
            {
                Instantiate(Effects[5], transform.position, Quaternion.identity);
                monsterDamageCooldown += monsterDamageCooldown * (player.abilitiesManager.FreezePunch() / 100);
            }

        }

    }
}
