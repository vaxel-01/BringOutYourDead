using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Accesspoint
    #region Manager
    public static PlayerManager manager;
    private void Awake()
    {
        if(manager == null)
        {
            manager=this;
        }
    }
    #endregion
    
    [Header("Types of collect")]
    public int deadBodyCollected;
    public int aliveBodyCollected;
    public int regTrashCollected;
    public int goldTrashCollected;
    public int gunter;

    [Header("Missed Objects")]
    public int objectsMissed;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onGamePlay.AddListener(ResetValues);
    }

    void Update()
    {
        if(aliveBodyCollected>=1)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void ResetValues()
    {
        deadBodyCollected=0;
        aliveBodyCollected=0;
        regTrashCollected=0;
        goldTrashCollected=0;
        objectsMissed=0;
        gunter=0;
    }

    public void Collect(string objectName)
    {
        switch (objectName)
        {
            case "aliveBody":
                aliveBodyCollected++;
                break;
            case "deadBody":
                deadBodyCollected++;
                break;
            case "goldTrash":
                goldTrashCollected++;
                SlownessIconSpawner.spawner.SpawnIcon();
                break;
            case "trash":
                regTrashCollected++;
                SlownessIconSpawner.spawner.SpawnIcon();
                break;
            case "MISSED":
                objectsMissed++;
                break;
            case "gunter":
                gunter++;
                break;
            default:
                break;
        }
    }

    public float TotalAmount()
    {
        return (deadBodyCollected+goldTrashCollected+regTrashCollected+objectsMissed);
    }

    public float TrashCollected()
    {
        return (regTrashCollected+goldTrashCollected);
    }
    public bool MoreGoldThanRegular()
    {
        if(goldTrashCollected>regTrashCollected)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
