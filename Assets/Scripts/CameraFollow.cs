using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float velocity = 5f;
    public float smooth = 0.5f;
    public float Max_X = 6f;
    public float Min_X = -5f;
    public float Min_Y = 0.3f;
    public Transform target;

	void FixedUpdate ()
    {
        Vector3 targetDirection = target.position - transform.position;
        velocity = targetDirection.magnitude * 5f;
        Vector3 targetPosition = transform.position + (targetDirection.normalized  * velocity * Time.deltaTime);
        //Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, smooth);
        //newPosition = new Vector3(transform.position.x, transform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smooth);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        clampCamPosition();
        //transform.position = newPosition;

	}

    void clampCamPosition()
    {
        Debug.Log("before clamp " + transform.position);
        float clampedX = Mathf.Clamp(transform.position.x, Min_X, Max_X);
        float clampedY = Mathf.Clamp(transform.position.y, Min_Y, 999999);
        Debug.Log("clamp y " + clampedY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
