using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigidBody;
    public float jumpForce = 200;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float moveSpeed = 10;

    private bool onGround = true;
    private LayerMask groundLayerMask;
    private bool facingRight = true;

	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }
	
	void Update () {
        applyFallMultiplier();
    }

    void FixedUpdate()
    {
        moveHorizontal();
        checkForJump();
        checkIfGrounded();
 
    }

    void moveHorizontal()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0)
        {
            rigidBody.velocity = new Vector2(moveHorizontal * moveSpeed, rigidBody.velocity.y);
            flipPlayer(moveHorizontal);
        }
    }

    void flipPlayer(float moveHorizontal)
    {
        if (moveHorizontal < 0)
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        else
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }

    void checkForJump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (onGround)
            {
                Jump();
                onGround = false;
            }
        }
    }

    void Jump()
    {
        rigidBody.AddForce(new Vector2(0.0f, jumpForce));
    }

    void checkIfGrounded()
    {
        if (rigidBody.velocity.y <= 0)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(rigidBody.position, Vector2.down, 1.2f, groundLayerMask);
            if (hit2D)
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }
    }

    void applyFallMultiplier()
    {
        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

}
