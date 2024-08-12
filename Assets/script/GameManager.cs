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

        DontDestroyOnLoad(transform.gameObject);
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
        //pointCounter();
        SceneManager.LoadScene(2);

    }

    //Points

    public void pointCounter()
    {
        float totalAmount = PlayerManager.manager.TotalAmount();
        float deadBodies = PlayerManager.manager.deadBodyCollected;
        float totalTrash = PlayerManager.manager.TrashCollected();
        float gold = PlayerManager.manager.goldTrashCollected;
        
        float pointsRewarded= deadBodies * collectDead;
        float pointsRemoved= totalTrash * (-collectTrash);
        float goldPoints = 0;
        
        float scoreCount = totalAmount * (pointsRewarded + pointsRemoved - PlayerManager.manager.objectsMissed);

        
        
        if(gold>0)
        {

            scoreCount += goldPoints;
        }

        //totalScore = scoreCount;
        
        ScoreList.ui.WriteScore(scoreCount, deadBodies, totalTrash, gold, PlayerManager.manager.objectsMissed);
    }
}
