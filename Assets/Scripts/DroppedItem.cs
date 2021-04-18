using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public int itemID;
    public Player Player;
    public bool isTrohpy, isFirework = false;
    public Transform[] routes;
    public float speedModifier;
    public float destroyAfterTime = 4f;
    public float dropRarity;
    public GameObject[] Effects;
    [SerializeField]
    private int routeToGo;
    private float tParam;
    private Vector2 coinPos;
    private bool corourtineAllows;

    void Start()
    {
        Player = FindObjectOfType<Player>();
        bool itemExist = Player.CollectionItemsId.Contains(itemID);

        if (isTrohpy)
        {
            InvokeRepeating("FireworkEffect", 0.25f, 0.5f);
        }

        if (!itemExist)
        {
            Player.CollectionItemsId.Add(itemID);
        }

        routeToGo = 0;
        tParam = 0f;
        speedModifier = 1f;
        corourtineAllows = true;
    }

    void Update()
    {
        if (isTrohpy)
        {
            routes[0] = GameObject.Find("routeTrophy").GetComponent<Transform>();
            StartCoroutine("TrophyGoInActive");
            Destroy(gameObject, destroyAfterTime);
        }
        else
        {
            destroyAfterTime = 0.9f;
            routes[0] = GameObject.Find("routeItem").GetComponent<Transform>();
            Destroy(gameObject, destroyAfterTime);
        }
        if (corourtineAllows)
        {
            StartCoroutine(GoByRoue(routeToGo));
        }
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

            coinPos = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

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
    void FireworkEffect()
    {
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height - 200)).y);
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vector2 spawnPos = new Vector2(spawnX, spawnY);
        Instantiate(Effects[0], spawnPos, Quaternion.identity);
    }

    IEnumerator TrophyGoInActive()
    {
        yield return new WaitForSeconds(0.9f);
        gameObject.SetActive(false);
    }
}
