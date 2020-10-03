using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressDialogue : MonoBehaviour
{
    public int id;
    public float fadeTime;
    public Text descriptionText, closeText;
    public Image portrait;
    [TextArea(1, 6)]
    public string text, close;
    public Player player;
    public bool isStartScene;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        descriptionText.text = text;
        closeText.text = close;
    }

    public void SelfClose()
    {
        player.DialogueProgress.Add(id);
        if (isStartScene)
        {
            gameObject.SetActive(false);
        }
        if (player.DialogueProgress.Contains(9))
        {
            player.StartScene = true;
        }
        Destroy(gameObject);
        Time.timeScale = 1f;
    }

}
