using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public string audioName;
    public float  scaleSpeed;
    public Vector3 targetScale;
    public bool playerTarget;
    void Start()
    {
        if (playerTarget)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 5f);
        }
        Destroy(gameObject, 1.0f);
        SoundManager.PlaySound(audioName);
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
    }
}
