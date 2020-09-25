using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressDialogue : MonoBehaviour
{
    public int id;
    public Text descriptionText, closeText;
    public Image portrait;
    [TextArea(1, 6)]
    public string text, close;
    public Player player;

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
        Destroy(gameObject);
    }
}
