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
    [Header("Spawn randomizer offset")]
    public float Offset=10;
    [Header("Objects")]
    [SerializeField] private GameObject[] fallingObjects;
    [SerializeField] private Transform parentObject;

    public float spawnTime = 2f;
    [Range(0 , 1)] public float spawnTimeModifier=0.1f;
    public float spawnSpeed = 1f;
    [Range(0 , 1)] public float spawnSpeedModifier=0.1f;

    //Start values
    private float _spawnTime=2f;
    private float _spawnSpeed=1f;

    private float timeUntilNextSpawn;
    private float timeAlive;
    
    // Start is called before the first frame update
    void Start()
    {
        //Add listeners for game start and game over
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        
        CalculateFactors();

        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilNextSpawn += Time.deltaTime;

        if(timeUntilNextSpawn >= _spawnTime)
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

    private void ResetFactors()
    {
        timeAlive=1f;
        _spawnTime=spawnTime;
        _spawnSpeed=spawnSpeed;
    }

    //speed and spawntime modifiers
    private void CalculateFactors()
    {
        _spawnTime = spawnTime / Mathf.Pow(timeAlive, spawnTimeModifier);
        _spawnSpeed = spawnSpeed * Mathf.Pow(timeAlive, spawnSpeedModifier);
    }
    
    //Actual spawner
    private void Spawn()
    {
        float minWidth = transform.position.x - Offset;
        float maxWidth = transform.position.x + Offset;

        GameObject objectToSpawn = fallingObjects[Random.Range(0, fallingObjects.Length)];

        GameObject spawnedObject = Instantiate(objectToSpawn, new Vector2(Random.Range(minWidth, maxWidth), transform.position.y), transform.rotation);
        spawnedObject.transform.parent = parentObject;
    }

    public float SpawnSpeed
    {
        get{ return _spawnSpeed; }
    }
}
