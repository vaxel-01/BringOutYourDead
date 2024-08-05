using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region ui
    public static UIManager ui;
    private void Awake()
    {
        if(ui==null)
        {
            ui=this;
        }
    }
    #endregion
    
    [SerializeField] private GameObject slownessIcon;
    
    private void Start()
    {
        GameManager.Instance.onGamePlay.AddListener(HideIcon);
    }
    
    public void HideIcon()
    {
        slownessIcon.SetActive(false);
    }

    public void ShowIcon()
    {
        slownessIcon.SetActive(true);
    }
}
