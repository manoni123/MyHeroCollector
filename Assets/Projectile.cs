using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public string audioName;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 50f);
        Destroy(gameObject, 1.0f);
        SoundManager.PlaySound(audioName);
    }
}
