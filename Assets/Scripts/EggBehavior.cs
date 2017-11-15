using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour {

    public float timeTillWalk = 5.0f;
    public float eggSpeed = 2f;
    public float launchSpeed = 5f;

    private Rigidbody2D rigidBody;
    private bool walking = false;
    private bool onGround = true;
    private LayerMask groundLayerMask;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");
        float launchXDirection = Random.Range(1, 10);
        float launchYDirection = Random.Range(1, 10);
        Vector2 launchDirection = new Vector2(launchXDirection, launchYDirection);
        launchDirection.Normalize();
        rigidBody.AddForce(launchDirection * launchSpeed);
        StartCoroutine(Incubate());
    }

    void Update ()
    {
        checkIfGrounded();
        determineWalkDirection();
    }

    void FixedUpdate()
    {
        if (walking && onGround)
        {
            rigidBody.velocity = new Vector2(eggSpeed, rigidBody.velocity.y);
        }
    }

    void determineWalkDirection()
    {
        // Each frame, egg has a 1% chance to change direction
        float random = Random.Range(0, 100); 
        if (random <= 1)
        {
            eggSpeed *= -1;
        }
    }

    void checkIfGrounded()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(rigidBody.position, Vector2.down, .65f, groundLayerMask);
        if (hit2D)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        Debug.Log(onGround);
    }

    IEnumerator Incubate()
    {
        yield return new WaitForSeconds(timeTillWalk);
        startWalking();
    }

    void startWalking()
    {
        walking = true;
    }


}
