using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeps : MonoBehaviour
{

    public static int health = 100;
    public static float speed = 10f;
    public int creepType = 0;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static float getSpeed()
    {
        return speed;
    }

    public static int getHealth()
    {
        return health;
    }


    public static void setHealth(int value)
    {
        health = value;
    }

}

