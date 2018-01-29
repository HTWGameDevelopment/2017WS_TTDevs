using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class towers : MonoBehaviour {

    [Header("Attributes")]

    public int type;
    public float range;
    public float dmg;
    public float spd;
    public float price;
    public int element; // 1=fire 2=Wind 3=Ice
    public int focus;

    [Header("OtherStuff")]

    public string creepTag = "Creep";
    public GameObject projectile;
    public Vector3 dir;
    public GameObject lockTarget = null;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("searchTarget" + type, 0f, 1/spd);
//        InvokeRepeating("shoot", 0.1f, 1/spd);


		
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void searchTarget(Action<GameObject> myMethod)
    {
        GameObject target = null;
        GameObject[] creeps = GameObject.FindGameObjectsWithTag(creepTag);
		float closestDistance = Mathf.Infinity;
        GameObject closestCreep = null;
        if (focus == 1)
        {
            foreach (GameObject creep in creeps)
            {
                float distanceToCreep = Vector3.Distance(transform.position, creep.transform.position);
                if (distanceToCreep < closestDistance)
                {
                    closestDistance = distanceToCreep;
                    closestCreep = creep;
                }

                if (closestCreep != null && closestDistance <= range)
                {
                    target = closestCreep;
                }
                else
                {
                    target = null;
                }


            }
        }
        else
        {
            GameObject[] creepsInRange = new GameObject[creeps.Length];
            int i = 0;
            foreach (GameObject creep in creeps)
            {
                float distanceToCreep = Vector3.Distance(transform.position, creep.transform.position);
                if (distanceToCreep <= range)
                {
                    creepsInRange[i] = creep;
                    i++;
                }
            }
            int highestWaypoint = -1;
            float distancetoFurthestWaypoint = Mathf.Infinity;
            foreach (GameObject inRange in creepsInRange)
            {
                if (inRange.GetComponent<EnemyMovement>().getWaypointIndex() >= highestWaypoint)
                {
                    if (inRange.GetComponent<EnemyMovement>().getWaypointIndex() > highestWaypoint)
                    {
                        highestWaypoint = inRange.GetComponent<EnemyMovement>().getWaypointIndex();
                        distancetoFurthestWaypoint = Mathf.Infinity;
                    }
                    if (distancetoFurthestWaypoint > inRange.GetComponent<EnemyMovement>().getDistancetoNextWaypoint())
                    {
                        distancetoFurthestWaypoint = inRange.GetComponent<EnemyMovement>().getDistancetoNextWaypoint();
                        closestCreep = inRange;
                    }
                }
            }
            target = closestCreep;
        }
        lockTarget = target;
        myMethod(target);
    }

    private void searchTarget1()
    {
        searchTarget(shoot1);
    }

    private void searchTarget2()
    {
        searchTarget(shoot2);
    }

    private void searchTarget3()
    {
        searchTarget(shoot3);
    }

    private void searchTarget4()
    {
        GameObject target = null;
        GameObject[] creeps = GameObject.FindGameObjectsWithTag(creepTag);

        foreach (GameObject creep in creeps)
        {
            float distanceToCreep = Vector3.Distance(transform.position, creep.transform.position);
            if (distanceToCreep <= range)
            {
                target = creep;
                shoot4(target);
            }

        }
    }

    private void shoot1(GameObject target)
    {
        if (target == null)
        {
            return;
        } else
        {
            Creeps shootTarget = target.GetComponent<Creeps>();
            shootTarget.checkDmg(dmg,element);

            Vector3 shootingPoint = transform.position;
            shootingPoint.y += 5f;
            GameObject bullet = Instantiate(projectile, shootingPoint, transform.rotation);
            dir = target.transform.position - shootingPoint;
            bullet.transform.Translate(dir.normalized * 10f, Space.World);
            Destroy(bullet, 2f);


        }

    }

    private void shoot2(GameObject target)
    {

    }

    private void shoot3(GameObject target)
    {

    }

    private void shoot4(GameObject target)
    {
        Creeps shootTarget = target.GetComponent<Creeps>();
        shootTarget.checkDmg(dmg, element);

    }


}
