using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;
    private float _speed; //Här ändrar vi på spelarens speed, så använder vi den övre som en reset-punkt (se ResetValues())
    [Range(0 , 1)] public float slownessModifier = 0.1f;
    [SerializeField] private float minimumSpeed; //Den minsta hastigheten en spelare kan ha.
    //om speed = 5 och slownessModifier = 0.3f , tar det ca 55 trash innan det slutar bli långsammare

    private float horizontal;
    [SerializeField] private Rigidbody2D rb2D;
    private bool isFacingRight;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        GameManager.Instance.onGamePlay.AddListener(ResetValues);
        GameManager.Instance.onGameOver.AddListener(GamePlayEnd);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isPlaying)
        {
            horizontal = Input.GetAxis("Horizontal");
            rb2D.velocity = new Vector2(horizontal * _speed, rb2D.velocity.y);
            animator.SetFloat("Speed", horizontal);
            //animator.SetFloat("Speed", Mathf.Abs(horizontal));

            //Flip();
            Slowness();
        }
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0) || (!isFacingRight && horizontal > 0))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Slowness()
    {
        float trashCollected = PlayerManager.manager.TrashCollected();

        if(trashCollected>0 && _speed>minimumSpeed)
        {
            _speed=speed/Mathf.Pow(trashCollected, slownessModifier);
        }
    }

    private void ResetValues()
    {
        _speed=speed;
    }

    private void GamePlayEnd()
    {
        animator.SetFloat("Speed", 0);
    }
}