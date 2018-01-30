using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public string creepTag = "Creep";

    public void explode(float dmg, int element, float range)
    {
        GameObject[] creeps = GameObject.FindGameObjectsWithTag(creepTag);
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
        foreach (GameObject inRange in creepsInRange)
        {
            if (inRange == null)
            {
                break;
            }
            Creeps target = inRange.GetComponent<Creeps>();
            target.checkDmg(dmg, element); 
            
        }
        Destroy(gameObject,1f);
    }
}
