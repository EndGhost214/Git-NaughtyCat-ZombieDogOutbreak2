using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZomSpawn : MonoBehaviour
{
    //private ZomMove zomMove;

    [SerializeField]
    TextMeshProUGUI Counter;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    public int TotalCount = 0;

    
    private float swarmerInterval = 1f;

    public enum ZomSpawnState{Spawning, Waiting, Counting};
    private Vector2 ZomBounds;
    private float zomWidth;
    private float zomHeight;

    public GameObject zom;

    public ZomSpawnState state = ZomSpawnState.Counting;

    void Start()
    {
        rb = zom.GetComponent<Rigidbody2D>();
        Counter.SetText("Zom Count = " + TotalCount);
        rb.velocity = new Vector2(10, 29);
        //ZomBounds = zomMove.boundsPosition;
        StartCoroutine(spawnEnemy(swarmerInterval, zom));
    }

    void Update()
    {
        //Debug.Log("Current Zoms: " + TotalCount);
        //check if zombies are in bound here
    }

    private IEnumerator spawnEnemy(float interval, GameObject zom)
    {
        Debug.Log("Current Zoms: " + TotalCount);
        state = ZomSpawnState.Spawning;
        GameObject newZom = Instantiate(zom, new Vector3(Random.Range(-10, 10), Random.Range(-4, 4), 0), Quaternion.identity);
        newZom.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 29);
        TotalCount++;
        Counter.SetText("Zom Count = " + TotalCount);
        Vector2 newZomPos = newZom.transform.position;
        //state = ZomSpawnState.Waiting;
        //yield return new WaitForSeconds(swarmerInterval);
        if(isInBounds(newZomPos) == true)
        {
            state = ZomSpawnState.Waiting;
            yield return new WaitForSeconds(swarmerInterval);
            StartCoroutine(spawnEnemy(swarmerInterval, zom));
            yield return new WaitForSeconds(5f);
            Debug.Log(" y= " + newZomPos.y);
            if(newZomPos.y < -1)
            {
                Debug.Log("Should stop here!!!!!======================================");
                yield break;
            }
        }
        else
        {
            Debug.Log("Should stop here!!!!!======================================");
            yield break;
        }
    }

    public bool isInBounds(Vector2 pos)
    { 
        if(pos.x > 10 || pos.x < -10 || pos.y > 4 || pos.y < -4)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
