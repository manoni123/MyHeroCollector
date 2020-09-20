using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private float shakeAmplitude;
    private Vector3 shakeActive;
    public bool isShake;
    public string audioName;

    // Update is called once per frame
    void Update()
    {
        //Camera Shake
        if (shakeAmplitude > 0)
        {
            shakeActive = new Vector3(Random.Range(-shakeAmplitude, shakeAmplitude), Random.Range(-shakeAmplitude, shakeAmplitude), 0);
            shakeAmplitude -= Time.deltaTime;
        }
        else
        {
            shakeActive = Vector3.zero;
        }

        if (isShake)
        {
            transform.position += shakeActive;
        }
    }

    public void CameraShake(float _shakeAmount)
    {
        shakeAmplitude = _shakeAmount;
        SoundManager.PlaySound(audioName);
    }
}
