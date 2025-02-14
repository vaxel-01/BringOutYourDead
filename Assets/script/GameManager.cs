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

    public bool isGunter;
    
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
        isGunter=false;
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
        float goldPoints = 0;
        float gunter = PlayerManager.manager.gunter;

        float pointsRewarded;
        float pointsRemoved;
        float scoreCount;
        
        

        //totalScore = scoreCount;

        if(isGunter)
        {
            ScoreList.ui.WriteScore(0, 0, 0, 0, PlayerManager.manager.objectsMissed, gunter);
        }
        else
        {
            pointsRewarded= deadBodies * collectDead;
            pointsRemoved= totalTrash * (-collectTrash);

            scoreCount = totalAmount * (pointsRewarded + pointsRemoved - PlayerManager.manager.objectsMissed);
            
            if(gold>0)
        {

            scoreCount += goldPoints;
        }
            
            ScoreList.ui.WriteScore(scoreCount, deadBodies, totalTrash, gold, PlayerManager.manager.objectsMissed, -1);
        }
        
        
        
    }
}
