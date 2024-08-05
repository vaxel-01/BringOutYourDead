using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //Accesspoint
    #region Instance
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance=this;
        }
    }
    #endregion
    
    [Header("Score")]
    public float totalScore=0f;
    
    public float collectDead;
    public float collectTrash;

    [Header("Game Management")]

    public bool isPlaying = false;
    public UnityEvent onGamePlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("k"))
        {
            if(isPlaying)
            {
                GameOver();
            }
            else
            {
                StartGame();
            }
        }
    }

    //Game States

    public void StartGame()
    {
        onGamePlay.Invoke();

        isPlaying=true;
    }

    public void GameOver()
    {
        onGameOver.Invoke();
        isPlaying=false;

        pointCounter();
    }

    //Points

    private void pointCounter()
    {
        float totalAmount = PlayerManager.manager.TotalAmount();
        
        float addedPoints = PlayerManager.manager.deadBodyCollected * collectDead;
        float removedPoints = (PlayerManager.manager.regTrashCollected + PlayerManager.manager.goldTrashCollected) * (-collectTrash);

        totalScore = addedPoints - removedPoints + PlayerManager.manager.goldTrashCollected;
    }
}
