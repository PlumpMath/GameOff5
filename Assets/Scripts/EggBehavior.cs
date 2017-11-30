using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour {

    public float timeTillWalk = 5.0f;
    public float timeTillHatch = 10.0f;
    public float eggSpeed = 2.0f;
    public float minLaunchSpeed = 400f;
    public float maxLaunchSpeed = 700f;
    public GameObject eggSplatter;
    public GameObject alien;

    private Rigidbody2D rigidBody;
    private bool walking = false;
    private bool onGround = true;
    private LayerMask groundLayerMask;
    private bool canBeDestroyed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");
        float launchXDirection = Random.Range(1, 10);
        float launchYDirection = Random.Range(1, 10);
        Vector2 launchDirection = new Vector2(-launchXDirection, launchYDirection);
        launchDirection.Normalize();
        float randForce = Random.Range(minLaunchSpeed, maxLaunchSpeed);
        rigidBody.AddForce(launchDirection * randForce);
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

    }

    IEnumerator Incubate()
    {
        yield return new WaitForSeconds(timeTillWalk);
        startWalking();
         StartCoroutine(WaitToHatch());
    }

    IEnumerator WaitToHatch()
    {
        yield return new WaitForSeconds(timeTillHatch);
        Hatch();
    }

    void Hatch()
    {
        Instantiate(eggSplatter, transform.position, Quaternion.identity);
        Instantiate(alien, transform.position, Quaternion.identity);
        SoundManagerScript.PlaySound("pop");
        Destroy(gameObject);
    }
    
    void startWalking()
    {
        walking = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (canBeDestroyed)
        {
            DestroyObject(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        canBeDestroyed = true;
    }


}
