using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabItem : MonoBehaviour {

    public float distance = 0.4f;
    public float grabRadius = 0.5f;
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
                Physics2D.queriesStartInColliders = true;
                Vector2 circleCastDirection = Vector2.right * transform.localScale.x;
                circleCastDirection.Normalize();
                hit = Physics2D.CircleCast(transform.position, 1f, circleCastDirection, distance, grabLayerMask);

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
