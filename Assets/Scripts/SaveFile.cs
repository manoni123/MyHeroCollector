using UnityEngine;
using System.Collections;
using TigerForge;
using System.Collections.Generic;

public class SaveFile : MonoBehaviour
{
    public Player player;
    public SoundManager soundManager;
    public List<int> CollectionItemsId = new List<int>();
    public List<int> SkillsItemsId = new List<int>();

    private void Awake()
    {
        EasyFileSave myFile = new EasyFileSave();
        
        if (myFile.Load())
        {
            player.level = myFile.GetInt("PlayerLevel");
            player.gold = myFile.GetInt("PlayerGold");
            player.diamond = myFile.GetInt("PlayerDiamond");
            player.skipForward = myFile.GetInt("PlayerSkipForward");
            soundManager.masterVolume = myFile.GetFloat("Volume");
            soundManager.isMute = myFile.GetBool("VolumeSprite");
            player.CollectionItemsId = myFile.GetList<int>("PlayerCollection");
            player.SkillItemsId = myFile.GetList<int>("PlayerSkills");
        }

        myFile.Dispose();
    }

    private void OnApplicationQuit()
    {
        Save();
    }


    public void Save()
    {
        EasyFileSave myFile = new EasyFileSave();

        myFile.Add("PlayerLevel", player.level);
        myFile.Add("PlayerGold", player.gold);
        myFile.Add("PlayerDiamond", player.diamond);
        myFile.Add("PlayerSkipForward", player.skipForward);
        myFile.Add("Volume", soundManager.masterVolume);
        myFile.Add("VolumeSprite", soundManager.isMute);
        for (int i = 0; i < player.CollectionItemsId.Count; i++)
        {
            if (!myFile.GetList<int>("PlayerCollection").Contains(i))
            {
                CollectionItemsId.Add(player.CollectionItemsId[i]);
            }
        }

        for (int i = 0; i < player.SkillItemsId.Count; i++)
        {
            if (!myFile.GetList<int>("PlayerSkills").Contains(i))
            {
                SkillsItemsId.Add(player.SkillItemsId[i]);
            }
        }
        myFile.Add("PlayerSkills", SkillsItemsId);
        myFile.Add("PlayerCollection", CollectionItemsId);
        myFile.Save();
    }
}   

