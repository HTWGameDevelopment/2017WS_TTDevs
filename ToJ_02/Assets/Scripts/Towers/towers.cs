using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towers : MonoBehaviour {

    [Header("Attributes")]

    public float range;
    public float dmg;
    public float spd;
    public float price;
    public float element; // 1=fire 2=Wind 3=Ice

    [Header("OtherStuff")]

    public Transform target = null;
    public string creepTag = "Creep";
    public GameObject projectile;
    public Vector3 dir;

	// Use this for initialization
	void Start () {
        InvokeRepeating("searchTarget", 0f, 0.3f);
        InvokeRepeating("shoot", 0f, 0.5f);


		
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

    void shoot()
    {
        if (target == null)
        {
            return;
        } else
        {
            Creeps shootTarget = target.GetComponent<Creeps>();
            shootTarget.takeDmg(20);
            
            Vector3 shootingPoint = transform.position;
            shootingPoint.y += 5f;
            GameObject bullet = Instantiate(projectile, shootingPoint, transform.rotation);
            dir = target.position - shootingPoint;
            bullet.transform.Translate(dir.normalized * 10f, Space.World);
            Destroy(bullet, 2f);


        }

    }


}
