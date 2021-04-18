using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropped : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] routes;
    public float speedModifier, destoryTime;
    public bool  isSlowCoin;
    [SerializeField]
    private int routeToGo;
    private float tParam;
    private Vector2 coinPos, p0, p1, p2, p3;
    private bool corourtineAllows;

    // Update is called once per frame
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        if (isSlowCoin)
        {
            speedModifier = 1f;
            destoryTime = 0.6f;
        }
        else
        {
            speedModifier = 2f;
            destoryTime = 0.45f;
        }
        corourtineAllows = true;
    }

    void Update()
    {
        routes[0] = GameObject.Find("routeCoin").GetComponent<Transform>();
        if (corourtineAllows)
        {
            StartCoroutine(GoByRoue(routeToGo));
        }
        Destroy(gameObject, destoryTime);
    }

    private IEnumerator GoByRoue(int routeNum)
    {
        corourtineAllows = false;
        Vector2 p0 = routes[routeNum].GetChild(0).position;
        Vector2 p1 = routes[routeNum].GetChild(1).position;
        Vector2 p2 = routes[routeNum].GetChild(2).position;
        Vector2 p3 = routes[routeNum].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            coinPos = Mathf.Pow(1- tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3*(1-tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.position = coinPos;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }
        corourtineAllows = true;
    }
}