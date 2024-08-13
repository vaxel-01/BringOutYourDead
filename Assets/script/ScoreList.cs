using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreList : MonoBehaviour
{
    #region ui
    public static ScoreList ui;
    private void Awake()
    {
        if(ui==null)
        {
            ui=this;
        }
    }
    #endregion 

    [Header("Points")]
    public TextMeshProUGUI totalScoreUI;
    public TextMeshProUGUI deadBodyUI;
    public TextMeshProUGUI trashUI;
    public TextMeshProUGUI goldTrashUI;
    public TextMeshProUGUI itemsMissedUI;
    [Header("Gunter title")]
    public TextMeshProUGUI deadBodyTitle;
    public TextMeshProUGUI trashTitle;
    public TextMeshProUGUI goldTitle;
    public TextMeshProUGUI missedBodyTitle;

    public GameObject Gunter;

    //De här skulle kunna visa hur man lägger till/tar bort poäng?
    //[Header("Point adding / removing")] 
    //public TextMeshProUGUI pointsAddedUI;
    //public TextMeshProUGUI pointsRemovedUI;
    //public TextMeshProUGUI goldAddedUI;


    void Start()
    {
        GameManager.Instance.pointCounter();
    }

    void Update()
    {
        if(GameManager.Instance.isGunter)
        {
            Gunter.SetActive(true);
        }
    }

    public void WriteScore(float ts, float db, float ta, float gta, float im, float gun)
    {
        if(gun == -1)
        {
            totalScoreUI.text = Mathf.RoundToInt(ts).ToString();
            deadBodyUI.text = Mathf.RoundToInt(db).ToString();
            trashUI.text = Mathf.RoundToInt(ta).ToString();
            goldTrashUI.text = Mathf.RoundToInt(gta).ToString();
            itemsMissedUI.text=Mathf.RoundToInt(im).ToString();
        }

        else
        {
            deadBodyTitle.text="Gunter";
            deadBodyUI.text = Mathf.RoundToInt(gun).ToString();
            trashTitle.text="Gunter feels";
            goldTitle.text="Gunter will";
            if(gun > 10)
            {
                trashUI.text="Satisfied... for now";
                goldTrashUI.text="certainly eat both your knees, maybe more";
            }
            else
            {
                trashUI.text="RAGE. Fear the unknown (and the known too)";
                goldTrashUI.text="not eat your knees, they don't look edible";
            }
            missedBodyTitle.text = Mathf.RoundToInt(im).ToString();
            if(im>0)
            {
                itemsMissedUI.text = "Gunters got away. The next world crisis is on you.";
            }
            else
            {
                itemsMissedUI.text = "Gunters got away. You're being cruel, he's just a kid";
            }
            totalScoreUI.text="Gunter will be back...";
        }

    }

}
