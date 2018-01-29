using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towers : MonoBehaviour {

    [Header("Attributes")]

    public int type;
    public float range;
    public float dmg;
    public float spd;
    public float price;
    public int element; // 1=fire 2=Wind 3=Ice

    [Header("OtherStuff")]

    public Transform target = null;
    public string creepTag = "Creep";
    public GameObject projectile;
    public Vector3 dir;

	// Use this for initialization
	void Start () {
        InvokeRepeating("searchTarget" + type, 0f, 1/spd);
//        InvokeRepeating("shoot", 0.1f, 1/spd);


		
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

    private void searchTarget1()
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
        shoot();
    }

    private void shoot()
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
            dir = target.position - shootingPoint;
            bullet.transform.Translate(dir.normalized * 10f, Space.World);
            Destroy(bullet, 2f);


        }

    }


}
