using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    public float effectDelayDestory;
    public string clipEffectName;
    private void Start()
    {
        StartCoroutine("clipDelay");
    }

    IEnumerator clipDelay()
    {
        SoundManager.PlaySound(clipEffectName);
        yield return new WaitForSeconds(effectDelayDestory);
        Destroy(gameObject);
    }
}
