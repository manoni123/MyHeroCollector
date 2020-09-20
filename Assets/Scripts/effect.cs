using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    public float effectDelayDestory;
    public string effectAudio;
    public bool towrdsEnemy;
    private void Start()
    {
        StartCoroutine("clipDelay");
    }

    IEnumerator clipDelay()
    {
        SoundManager.PlaySound(effectAudio);
        yield return new WaitForSeconds(effectDelayDestory);
        Destroy(gameObject);
    }

}
