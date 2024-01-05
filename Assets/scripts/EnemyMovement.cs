using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public Transform[] waypoints;
	Transform targetWayPoint;
	public float tgtDistanceOffse = 0.1f;
	float lastDistanceToTarget = 0f;
	public float moveSpeed = 10f;
    public Rigidbody2D rb;
	int currentWayPoint; 
	// Start is called before the first frame update
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		targetWayPoint = waypoints[currentWayPoint];
		lastDistanceToTarget = Vector3.Distance(transform.position, targetWayPoint.position);
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
		float distanceToTarget = Vector3.Distance(transform.position, targetWayPoint.position);
		if ((distanceToTarget < tgtDistanceOffse) || (distanceToTarget > lastDistanceToTarget))
		{
			currentWayPoint++;
			if (currentWayPoint >= waypoints.Length)
				currentWayPoint = 0;
			targetWayPoint = waypoints[currentWayPoint];
			lastDistanceToTarget = Vector3.Distance(transform.position, targetWayPoint.position);
		}
		else
		{
			lastDistanceToTarget = distanceToTarget;
		}

		Vector3 dir = (targetWayPoint.position - transform.position).normalized;
		rb.MovePosition(transform.position + dir * (moveSpeed * Time.fixedDeltaTime));

    }
}
