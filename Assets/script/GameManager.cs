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

    void Start()
    {
        StartGame();
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
        
        float pointsRewarded=PlayerManager.manager.deadBodyCollected * collectDead;
        float pointsRemoved= PlayerManager.manager.TrashCollected() * (-collectTrash);
        
        float scoreCount = totalAmount * (pointsRewarded + pointsRemoved - PlayerManager.manager.objectsMissed);

        if(PlayerManager.manager.MoreGoldThanRegular())
        {
            scoreCount += PlayerManager.manager.goldTrashCollected * collectTrash;
        }
        else
        {
            scoreCount = scoreCount * (PlayerManager.manager.objectsMissed / PlayerManager.manager.goldTrashCollected);
        }

        totalScore = Mathf.Round(scoreCount);

        if(totalScore < 0)
        {
            totalScore=0;
        }

    }
}
