using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : MonoBehaviour
{
    float speed = 25.0f;
    public Transform target;
    bool isMoving = true; // Variable to control movement

    void Start()
    {
        MoveToNextWaypoint();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void MoveToNextWaypoint()
    {
        if (target != null)
        {
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WayPoint"))
        {

            WayPoint waypoint = other.GetComponent<WayPoint>();
            if (waypoint != null)
            {
                target = waypoint.nextPoint;
                transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                // Pause movement briefly to simulate a turn
                isMoving = false;
                StartCoroutine(ResumeMovementAfterDelay(1.0f)); // Adjust delay as needed
            }
        }
    }

    IEnumerator ResumeMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMoving = true; // Resume movement after delay
        MoveToNextWaypoint(); // Look at the next waypoint
    }
}



