using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towers : MonoBehaviour {

    [Header("Attributes")]

    public float range;
    public float dmg;
    public float spd;

    [Header("OtherStuff")]

    public Transform target = null;
    public string creepTag = "Creep";

	// Use this for initialization
	void Start () {
        InvokeRepeating("searchTarget", 0f, 0.3f);


		
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            return;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void searchTarget()
    {
        GameObject[] creeps = GameObject.FindGameObjectsWithTag(creepTag);
		float closestDistance = Mathf.Infinity;
        GameObject closestCreep = null;

        foreach(GameObject creep in creeps)
        {
            float distanceToCreep = Vector3.Distance(transform.position, creep.transform.position);
            if (distanceToCreep < closestDistance)
            {
                closestDistance = distanceToCreep;
                closestCreep = creep;
            }

            if (closestCreep != null && closestDistance <= range)
            {
                target = closestCreep.transform;
                
            } else
            {
                target = null;
            }


        }
    }


}
