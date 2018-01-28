using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeps : MonoBehaviour
{

    public int health = 100;
    public static float speed = 10f;
    public int creepType = 0;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
            PlayerStats.single.creepDestroyed();
        }
    }

    public static float getSpeed()
    {
        return speed;
    }

    public int getHealth()
    {
        return health;
    }


    public void setHealth(int value)
    {
        health = value;
    }

    public void takeDmg(int value)
    {
        health -= value;
    }
}

