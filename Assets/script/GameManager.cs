using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    void Update()
    {
        if(!isPlaying && Input.GetKeyDown("k"))
        {
            StartGame();
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
        //onGameOver.Invoke();
        isPlaying=false;

        pointCounter();

        SceneManager.LoadScene(2);

    }

    //Points

    private void pointCounter()
    {
        float totalAmount = PlayerManager.manager.TotalAmount();
        
        float pointsRewarded=PlayerManager.manager.deadBodyCollected * collectDead;
        float pointsRemoved= PlayerManager.manager.TrashCollected() * (-collectTrash);
        
        float scoreCount = totalAmount * (pointsRewarded + pointsRemoved - PlayerManager.manager.objectsMissed);

        if(PlayerManager.manager.goldTrashCollected>0)
        {
            if(PlayerManager.manager.MoreGoldThanRegular())
            {
                scoreCount += PlayerManager.manager.goldTrashCollected;
            }
            else
            {
                scoreCount += Mathf.Round(PlayerManager.manager.goldTrashCollected / collectTrash);
            }
        }

        totalScore = scoreCount;

        if(totalScore < 0) //Hindrar att spelaren får ett negativt score (den får bara alltid 0 istället)
        {
            totalScore = 0;
        }

    }
}
