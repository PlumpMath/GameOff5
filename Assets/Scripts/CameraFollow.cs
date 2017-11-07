using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float velocity = 5f;
    public float smooth = 0.5f;
    public Transform target;

	void FixedUpdate ()
    {
        Vector3 targetDirection = target.position - transform.position;
        velocity = targetDirection.magnitude * 5f;
        Vector3 targetPosition = transform.position + (targetDirection.normalized  * velocity * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smooth);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
