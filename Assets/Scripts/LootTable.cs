﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    public GameObject thisloot;
    public float lootChance;
}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;
    public GameObject LootObject()
    {
        Debug.Log("foundLootObject");
        float cumProb = 0f;
        float currentProb = Random.Range(0, 100);
        for (int i = 0; i < loots.Length; i++)
        {
            cumProb += loots[i].lootChance;
            Debug.Log("drop chance is" + cumProb + "and random result is");
            if (currentProb <= cumProb)
            {
                return loots[i].thisloot;
            }
        }
        return null;
    }

}