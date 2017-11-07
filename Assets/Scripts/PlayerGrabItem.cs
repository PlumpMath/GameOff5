using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabItem : MonoBehaviour {

    public float distance = 0.1f;
    public float grabRadius = 0.5f;
    public float throwForce = 2f;
    public Transform grabPoint;

    private RaycastHit2D hit;
    private bool hasItem = false;
    private LayerMask grabLayerMask;
    private Rigidbody2D playerRigidBody; 


    void Start ()
    {
        grabLayerMask = LayerMask.GetMask("Grab");
        playerRigidBody = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        if (Input.GetButtonDown("Grab"))
        {
            Debug.Log("Grab button pushed");
            if (!hasItem)
            {
                grabItem();
            }
            else
            {
                throwItem();
            }
        }


        if (hasItem)
        {
            hit.collider.gameObject.transform.position = grabPoint.position;
        }
	}

    void grabItem()
    {
        Physics2D.queriesStartInColliders = true;
        Vector2 circleCastDirection = Vector2.right * transform.localScale.x;
        circleCastDirection.Normalize();
        Vector2 circleCastOrigin = new Vector2(transform.position.x + (transform.localScale.x * 0.1f), transform.position.y);
        hit = Physics2D.CircleCast(circleCastOrigin, 1f, circleCastDirection, distance, grabLayerMask);

        if (hit)
        {
            hasItem = true;
        }
    }

    void throwItem()
    {
        hasItem = false;
        Rigidbody2D itemRigidBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
        if (itemRigidBody != null)
        {
            itemRigidBody.velocity = new Vector2(transform.localScale.x, 1.5f) * (throwForce + (playerRigidBody.velocity.x * transform.localScale.x * 0.02f));
        }
    }

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, transform.position +Vector3.right * transform.localScale.x*distance);
    }
}
