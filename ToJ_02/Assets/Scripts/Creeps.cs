using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeps : MonoBehaviour
{

    public static int health = 100;
    public static int rstnc_fire = 0;
    public static int rstnc_water = 0;
    public static int rstnc_wind = 0;
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

    public static int getFire()
    {
        return rstnc_fire;
    }

    public static int getWater()
    {
        return rstnc_water;
    }

    public static int getWind()
    {
        return rstnc_wind;
    }

    public static void setHealth(int value)
    {
        health = value;
    }

    public static void setFire(int value)
    {
        rstnc_fire = value;
    }

    public static void setWater(int value)
    {
        rstnc_water = value;
    }
    public static void setWind(int value)
    {
        rstnc_wind = value;
    }

}

