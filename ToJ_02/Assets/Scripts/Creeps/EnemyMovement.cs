﻿
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float speed;

    private Transform target;
    private int waypointIndex = 0;

	// Use this for initialization
	void Start () {
        target = Waypoints.points[waypointIndex];
	}
    
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = target.position - transform.position;
        speed = gameObject.GetComponent<Creeps>().getSpeed();
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            getNextWaypoint();
        }
		
	}

    public int getWaypointIndex()
    {
        return waypointIndex;
    }

    public float getDistancetoNextWaypoint()
    {
        float distancetoNextWaypoint = Vector3.Distance(transform.position, target.position);
        return distancetoNextWaypoint;

    }

    void getNextWaypoint()
    {
        if (waypointIndex == Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            gameObject.GetComponent<Creeps>().DestroyCreep(false);
			PlayerStats.single.reduceHealth (1);
        }
        else
        {
            waypointIndex++;
            target = Waypoints.points[waypointIndex];
        }
    }
}
