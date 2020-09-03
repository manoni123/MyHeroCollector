using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    Player Player;
    Chest Chest;
    public int monsterId;
    public float monsterHealth;
    public int healthRegen;
    public int chestId;
    public float dropChance;
    public bool isSpawn = false;
    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        Chest = GameObject.Find("PlayerUI").GetComponent<Chest>();
        Player.scoreToNextLevel = monsterHealth;
    }
    void Update()
    {
        //show player score / next monster hp
        Player.scoreText.text = Player.score.ToString() + " / " + monsterHealth.ToString();

        if (Player.score >= Player.scoreToNextLevel && isSpawn)
        {
            Death();
        }
    }

    void Death()
    {
        {
            Chest.GetComponent<Chest>().ChestOpen();
            Destroy(gameObject);
            Player.score = 0;
        }
    }
}
