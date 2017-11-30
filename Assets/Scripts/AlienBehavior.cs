using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour {

    public float speed;
    public float flySpeed;
    public float timeTillFly;
    public GameObject eggSplatter;

    private GameObject player;
    private Rigidbody2D playerRb;
    private Rigidbody2D rigidBody;
    private Transform playerTransform;
    private LayerMask alienLayerMask;
    private bool flying = false;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerRb = player.GetComponent<Rigidbody2D>();
        playerTransform = player.GetComponent<Transform>();
        alienLayerMask = LayerMask.GetMask("Alien");
        StartCoroutine(FlyAway());
    }

    // Update is called once per frame
    void Update()
    {
        determineWalkDirection();
        RaycastHit2D hit2D = Physics2D.Raycast(playerRb.position, Vector2.down, 0.9f, alienLayerMask);


        Vector2 forward = Vector2.down * 0.5f;
        Debug.DrawLine(playerRb.position, playerRb.position + forward, Color.green);
        if (hit2D.rigidbody == rigidBody)
        {
            Instantiate(eggSplatter, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound("squish");
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (flying)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, flySpeed);
        }
        else
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        }
    }

    void determineWalkDirection()
    {
        // Each frame, egg has a 1% chance to change direction
        float random = Random.Range(0f, 100f);
        if (random <= 0.5)
        {
            speed *= -1;
        }
    }

    IEnumerator FlyAway()
    {
        yield return new WaitForSeconds(timeTillFly);
        flying = true;
    }

    void OnDrawGizmos()
   {
       Gizmos.color = Color.green;
       Gizmos.DrawLine(playerTransform.position, playerTransform.position +Vector3.down* playerTransform.localScale.x*0.2f);
    }
}
