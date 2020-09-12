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
    public int monsterDamage;
    public float monsterDamageCooldown;
    public int chestId;
    public int goldDrop;
    public bool isSpawn = false, isBoss;
    public GameObject[] Effects;
    Vector3 objectSpawn = new Vector3(0, 2.3f, 0);
    /// <summary>Effects explain
    /// #0 = damage by normal attack
    /// #1 = damage by skill
    /// #2 = attack player w/ projectile
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
            player.scoreText.text = player.score.ToString() + " / " + monsterHealth.ToString();
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
        player.score -= monsterDamage;
    }

    void MonsterEffects()
    {
        //all effect casued on mob will start here
        if (player.normalAttackEffect)
        {
            Instantiate(Effects[0], transform.position, Quaternion.identity);
            player.normalAttackEffect = false;
        }
        if (player.specialAttackEffect)
        {
            Instantiate(Effects[1], transform.position, Quaternion.identity);
            player.specialAttackEffect = false;
        }
    }

    void Death()
    {
        {
            chest.GetComponent<Chest>().ChestOpen();
            MakeLoot();
            player.chestCount++;
            GoldDropped();
            Destroy(gameObject);
            player.score = 0;
            CancelInvoke("DamagePlayer");
        }
    }
    void GoldDropped()
    {
        int sum = (monsterLevel * goldDrop) + (player.level * 2);
        player.gold += sum;
    }

    private void MakeLoot()
    {
        Debug.Log("Loot function");

        if (lootTable != null)
        {
            GameObject current = lootTable.LootObject();
            if (current != null)
            {
                Debug.Log("should be dropped somthing");
                //instantiate an object and animate it towrds the same position + a fixed amount of random range from current transform
                Instantiate(current.gameObject, transform.position + objectSpawn, Quaternion.identity) ;
                chest.chestText.text = "You got big drop buddy!";
            }
        }
    }


}
