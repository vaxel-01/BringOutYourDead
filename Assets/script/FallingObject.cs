using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    //Accesspoint
    #region obj
    public static FallingObject obj;
    private void Awake()
    {
        if(obj==null)
        {
            obj=this;
        }
    }
    #endregion
    [SerializeField] GameObject sound;

    [SerializeField] private Rigidbody2D rb2D;

    [SerializeField] private float speed;
    
    [SerializeField] private string objectType;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        speed = BodySpawner.spawner.SpawnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x , (-speed));
        if(objectType=="gunter" && GameManager.Instance.isGunter==false)
        {
            GameManager.Instance.isGunter=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Cart")
        {
            Debug.Log("hit player!");
            Instantiate(sound, transform.position, transform.rotation);
            Destroy(gameObject);
            PlayerManager.manager.Collect(objectType);
        }
        if(collision.transform.tag == "ground")
        {
            Destroy(gameObject);
            if(objectType == "deadBody" || objectType == "gunter")
            {
                PlayerManager.manager.Collect("MISSED");
            }
            
        }
    }

}
