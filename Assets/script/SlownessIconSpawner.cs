using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlownessIconSpawner : MonoBehaviour
{
    #region
    public static SlownessIconSpawner spawner;
    private void Awake()
    {
        if(spawner==null)
        {
            spawner=this;
        }
    }
    #endregion

    [SerializeField] private GameObject[] slowIcons;
    [SerializeField] private Transform parentObject;

    [SerializeField] private float iconPosX;
    private float _iconPosX;
    [SerializeField] private float iconPosMod;

    void Start()
    {
        GameManager.Instance.onGameOver.AddListener(HideIcons);
        iconPosX=transform.position.x;
        _iconPosX = iconPosX;
    }

    private void HideIcons()
    {
        foreach(Transform child in parentObject)
        {
            Destroy(child.gameObject);
        }
        _iconPosX=iconPosX;
    }

    public void SpawnIcon()
    {
        GameObject spawnedObject = Instantiate(slowIcons[0], new Vector2(_iconPosX, transform.position.y), transform.rotation);
        spawnedObject.transform.parent = parentObject;
        _iconPosX += iconPosMod;
    }
}
