using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour
{

    #region 
    public static BodySpawner spawner;
    private void Awake()
    {
        if(spawner==null)
        {
            spawner=this;
        }
    }
    #endregion
    [SerializeField] private GameObject[] fallingObjects;
    [SerializeField] private Transform parentObject;

    public float spawnTime = 2f;
    public float spawnSpeed = 1f;

    private float timeUntilNextSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        //Add listeners for game start and game over
    }

    // Update is called once per frame
    void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilNextSpawn += Time.deltaTime;

        if(timeUntilNextSpawn >= spawnTime)
        {
            Spawn();
            timeUntilNextSpawn=0f;
        }
    }

    //Clears the objects spawned in game (USE FOR RESTARTING GAME)
    private void ClearObjects()
    {
        foreach(Transform child in parentObject)
        {
            Destroy(child.gameObject);
        }
    }
    
    //Actual spawner
    private void Spawn()
    {
        GameObject objectToSpawn = fallingObjects[Random.Range(0, fallingObjects.Length)];

        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        spawnedObject.transform.parent = parentObject;
    }

    public float SpawnSpeed
    {
        get{ return spawnSpeed; }
    }
}
