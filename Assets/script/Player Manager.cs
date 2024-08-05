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

        if(regTrashCollected==1 || goldTrashCollected==1)
        {
            UIManager.ui.ShowIcon();
        }
    }

    private void ResetValues()
    {
        deadBodyCollected=0;
        aliveBodyCollected=0;
        regTrashCollected=0;
        goldTrashCollected=0;
        objectsMissed=0;
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
                break;
            case "trash":
                regTrashCollected++;
                break;
            case "MISSED":
                objectsMissed++;
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
}
