using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public string audioName;
    public float  scaleSpeed, positionSpeed, destroyAfterSeconds;
    public Vector3 targetScale, enemyPosition, skillPosition;
    public GameObject afterEffect;
    public bool playerTarget, enemyTarget, hasEffect;
    void Start()
    {
        if (hasEffect)
        {
            transform.position = skillPosition;
        }
        if (playerTarget)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.down * 5f);
        }
        Destroy(gameObject, destroyAfterSeconds);
        SoundManager.PlaySound(audioName);
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
        if (enemyTarget)
        {
            transform.position = Vector3.Lerp(transform.position, enemyPosition, positionSpeed * Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        if (hasEffect)
        {
            Instantiate(afterEffect, transform.position, Quaternion.identity);
        }
    }
}
