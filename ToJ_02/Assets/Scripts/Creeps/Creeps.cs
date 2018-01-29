using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeps : MonoBehaviour
{

    public int health;
    public float speed;
    public int creepType;
    public int reward;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            PlayerStats.single.updateMoney(reward);
            PlayerStats.single.creepDestroyed();
            Destroy(gameObject);
        }
    }

    public float getSpeed()
    {
        return speed;
    }

    public int getHealth()
    {
        return health;
    }

    public int getReward()
    {
        return reward;
    }

    public void setValue(int value)
    {
        reward = value;
    }

    public void setSpeed(float value)
    {
        speed = value;
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

