using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovment : MonoBehaviour
{
    [SerializeField] public float speed; // the speed of movement
    [SerializeField] private LayerMask wallLayer;
    public Vector2 direction = Vector2.right; // the direction of movement
    public Transform groundCheck; // a reference to a ground check object

    private Rigidbody2D rb; // a reference to the Rigidbody2D component
    private BoxCollider2D boxCollider;
    private bool isGrounded = false; // a flag indicating whether the object is grounded
    private bool isFacingRight = true; // a flag indicating whether the object is facing right

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed, rb.velocity.y);

        // flip the object if it hits a wall
        if (onWall())
        {
            Flip();
        }
    }

    void Flip()
    {
        // switch the direction of movement
        direction *= -1;

        // flip the object horizontally
        transform.Rotate(0f, 180f, 0f);

        // update the facing flag
        isFacingRight = !isFacingRight;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
