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

    //[Header("Point adding / removing")]
    //public TextMeshProUGUI pointsAddedUI;
    //public TextMeshProUGUI pointsRemovedUI;
    //public TextMeshProUGUI goldAddedUI;


    void Start()
    {
        GameManager.Instance.pointCounter();
    }

    public void WriteScore(float ts, float db, float ta, float gta, float preward, float premove, float pgold)
    {
        totalScoreUI.text = Mathf.RoundToInt(ts).ToString();
        deadBodyUI.text = Mathf.RoundToInt(db).ToString();
        trashUI.text = Mathf.RoundToInt(ta).ToString();
        goldTrashUI.text = Mathf.RoundToInt(gta).ToString();

        //pointsAddedUI.text = Mathf.RoundToInt(preward).ToString();
        //pointsRemovedUI.text = Mathf.RoundToInt(premove).ToString();
        //goldAddedUI.text = Mathf.RoundToInt(pgold).ToString();
    }

}
