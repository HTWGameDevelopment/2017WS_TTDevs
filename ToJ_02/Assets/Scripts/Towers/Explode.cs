using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    private Color color;
    public string creepTag = "Creep";
    private GameObject goal;
    private float dmg;
    private bool explosion;
    private float range;
    private int element;
    private float speed;
    public Light ligh;

    void Start()
    {
    }
    void Update()
    {
        if(goal == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = goal.transform.position - transform.position;
        float travel = speed * Time.deltaTime;
        if(dir.magnitude <= travel)
        {
            if (explosion)
            {
                Light lt = Instantiate(ligh, goal.transform.position, transform.rotation);
                lt.transform.parent = goal.transform;
                lt.color = color;
                lt.range = range + 4.0f;
                Destroy(lt, 0.3f);
                explode();
                return;
            }
            Light lit = Instantiate(ligh, goal.transform.position, transform.rotation);
            lit.transform.parent = goal.transform;
            lit.color = color;
            lit.range = 4.0f;
            Destroy(lit, 0.3f);
            goal.GetComponent<Creeps>().checkDmg(dmg, element);
            Destroy(gameObject);
            return;
        }

        transform.Translate(dir.normalized * travel, Space.World);

    }



    public void setTarget(GameObject _goal, float _dmg, bool _explosion, float _range, int _element, float _speed, Color _color) 
    {
        goal = _goal;
        dmg = _dmg;
        explosion = _explosion;
        range = _range;
        element = _element;
        speed = _speed;
        color = _color;
        gameObject.GetComponent<Renderer>().material.color = _color;
    }

    public void explode()
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

        Destroy(gameObject);
    }
}
