using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabItem : MonoBehaviour {

    public float distance = 2f;
    public float throwForce = 2f;
    public Transform grabPoint;

    private RaycastHit2D hit;
    private bool hasItem = false;
    private LayerMask grabLayerMask;


    void Start ()
    {
        grabLayerMask = LayerMask.GetMask("Grab");
    }
	
	void Update ()
    {
        if (Input.GetButtonDown("Grab"))
        {
            Debug.Log("Grab button pushed");
            if (!hasItem)
            {
                Physics2D.queriesStartInColliders = false;
                //hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, grabLayerMask);
                //Vector2 circleCastOrigin = new Vector2(transform.position.x + (distance * transform.localScale.x), transform.position.y);
                hit = Physics2D.CircleCast(transform.position, 2, Vector2.right * transform.localScale.x, distance, grabLayerMask);
                
                //Debug.DrawRay(transform.position, Vector2.right * transform.localScale.x, Color.green);
                if (hit)
                {
                    Debug.Log("Hit something!");
                    hasItem = true;
                }
            }
            else
            {
                hasItem = false;
                Rigidbody2D itemRigidBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                if (itemRigidBody != null)
                {
                    itemRigidBody.velocity = new Vector2(transform.localScale.x, 1) * throwForce;
                }
            }
        }


        if (hasItem)
        {
            hit.collider.gameObject.transform.position = grabPoint.position;
        }
	}

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, transform.position +Vector3.right * transform.localScale.x*distance);
    }
}
