using UnityEngine;
using System.Collections;
using TigerForge;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class SaveFile : MonoBehaviour
{
    public Player player;
    public SoundManager soundManager;
    public List<int> CollectionItemsId = new List<int>();

    private void Awake()
    {
        EasyFileSave myFile = new EasyFileSave();
        
        if (myFile.Load())
        {
            player.level = myFile.GetInt("PlayerLevel");
            soundManager.masterVolume = myFile.GetFloat("Volume");
            soundManager.isMute = myFile.GetBool("VolumeSprite");
            player.CollectionItemsId = myFile.GetList<int>("PlayerCollection");
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
        myFile.Add("Volume", soundManager.masterVolume);
        myFile.Add("VolumeSprite", soundManager.isMute);
        for (int i = 0; i < player.CollectionItemsId.Count; i++)
        {
            if (!myFile.GetList<int>("PlayerCollection").Contains(i))
            {
                CollectionItemsId.Add(player.CollectionItemsId[i]);
            }
        }

        myFile.Add("PlayerCollection", CollectionItemsId);
        myFile.Save();
    }
}   

