using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class towers : MonoBehaviour {
    public static float TYPE2EXPLOSIONRANGE = 7.0f;
    public static float TYPE3EXPLOSIONRANGE = 12.0f;
    public static float BULLETSPEED = 50.0f;
    [Header("Attributes")]

    public int type;
    public float range;
    public float dmg;
    public float spd;
    public float price;
    public int element; // 1=fire 2=Wind 3=Ice
    public int focus;

    [Header("OtherStuff")]

    public Color fire;
    public Color wind;
    public Color ice;
    public Light ligh;
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

    public void upgrade()
    {
        dmg *= 1.1f;
        price *= 1.1f;
    }

    public void setFocus(int value)
    {
        focus = value;
    }

    public float getPrice()
    {
        return price;
    }

    public int getFocus()
    {
        return focus;
    }

    public int getElement()
    {
        return element;
    }

    public float getDmg()
    {
        return dmg;
    }

    public float getRange()
    {
        return range;
    }

    public float getSpd()
    {
        return spd;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private Color chooseColor()
    {
        switch (element)
        {
            case 1:
                return fire;
            case 2:
                return wind;
            case 3:
                return ice;
            default:
                return fire;
        }
    }

    private void searchTarget(Action<GameObject> myMethod)
    {
        GameObject target = null;
        GameObject[] creeps = GameObject.FindGameObjectsWithTag(creepTag);
        GameObject closestCreep = null;
        switch (focus)
        {
            case 1:
                {
                    float closestDistance = Mathf.Infinity;
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
                    break;
                }
            case 2:
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
                        if (inRange == null && closestCreep == null)
                        {
                            target = null;
                        }
                        else
                        {
                            if (inRange == null)
                            {
                                target = closestCreep;
                            }
                            else
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
                        }
                    }
                    target = closestCreep;
                    break;
                }
            case 3:
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
                int highestWaypoint = int.MaxValue;
                float distancetoNextWaypoint = 0;
                foreach (GameObject inRange in creepsInRange)
                {
                    if (inRange == null && closestCreep == null)
                    {
                        target = null;
                    }
                    else
                    {
                        if (inRange == null)
                        {
                            target = closestCreep;
                        }
                        else
                        {
                            if (inRange.GetComponent<EnemyMovement>().getWaypointIndex() <= highestWaypoint)
                            {
                                if (inRange.GetComponent<EnemyMovement>().getWaypointIndex() < highestWaypoint)
                                {
                                    highestWaypoint = inRange.GetComponent<EnemyMovement>().getWaypointIndex();
                                    distancetoNextWaypoint = 0;
                                }
                                if (distancetoNextWaypoint < inRange.GetComponent<EnemyMovement>().getDistancetoNextWaypoint())
                                {
                                    distancetoNextWaypoint = inRange.GetComponent<EnemyMovement>().getDistancetoNextWaypoint();
                                    closestCreep = inRange;
                                }
                            }
                        }
                    }
                }
                target = closestCreep;
                break;
                }
            default:
                target = null;
                break;
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
        bool shoot = false;

        foreach (GameObject creep in creeps)
        {
            float distanceToCreep = Vector3.Distance(transform.position, creep.transform.position);
            if (distanceToCreep <= range)
            {
                target = creep;
                shoot4(target);
                shoot = true;
            }

        }
        if (shoot)
        {
            Light lit = Instantiate(ligh, transform.position, transform.rotation);
            lit.color = chooseColor();
            lit.range = range;
            Destroy(lit, 0.2f);
        }
    }

    private void shoot1(GameObject target)
    {
        if (target == null)
        {
            return;
        } else
        {
            //Creeps shootTarget = target.GetComponent<Creeps>();
            //shootTarget.checkDmg(dmg,element);

            //Vector3 shootingPoint = transform.position;
            //shootingPoint.y += 5f;
            //GameObject bullet = Instantiate(projectile, shootingPoint, transform.rotation);
            //dir = target.transform.position - shootingPoint;
            //bullet.transform.Translate(dir.normalized * 10f, Space.World);
            //Destroy(bullet, 2f);

            Vector3 shootingPoint = transform.position;
            shootingPoint.y += 5f;
            GameObject bullet = Instantiate(projectile, shootingPoint, transform.rotation);
            bullet.GetComponent<Explode>().setTarget(target, dmg, false, 0.0f, element, BULLETSPEED, chooseColor());


        }
    }

    private void shoot2(GameObject target)
    {
        if (target == null)
        {
            return;
        }
        else
        {

            Vector3 shootingPoint = transform.position;
            shootingPoint.y += 5f;
            GameObject bullet = Instantiate(projectile, shootingPoint, transform.rotation);
            bullet.GetComponent<Explode>().setTarget(target, dmg, true, TYPE2EXPLOSIONRANGE, element, BULLETSPEED, chooseColor());

        }
    }

    private void shoot3(GameObject target)
    {
        if (target == null)
        {
            return;
        }
        else
        {

            Vector3 shootingPoint = transform.position;
            shootingPoint.y += 5f;
            GameObject bullet = Instantiate(projectile, shootingPoint, transform.rotation);
            bullet.GetComponent<Explode>().setTarget(target, dmg, true, TYPE3EXPLOSIONRANGE, element, BULLETSPEED, chooseColor());

        }
    }

    private void shoot4(GameObject target)
    {
        if (target == null)
        {
            return;
        }
        else
        {
            
            Creeps shootTarget = target.GetComponent<Creeps>();
            shootTarget.checkDmg(dmg, element);
        }
    }


}
