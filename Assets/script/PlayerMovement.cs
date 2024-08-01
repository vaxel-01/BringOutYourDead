using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float horizontal;
    [SerializeField] private Rigidbody2D rb2D;
    private bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(horizontal * speed, rb2D.velocity.y);

        Flip();
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
}