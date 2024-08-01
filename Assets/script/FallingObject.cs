using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    #region
    public static FallingObject obj;
    private void Awake()
    {
        if(obj==null)
        {
            obj=this;
        }
    }
    #endregion

    [SerializeField] private Rigidbody2D rb2D;

    [SerializeField] private float speed;
    
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
