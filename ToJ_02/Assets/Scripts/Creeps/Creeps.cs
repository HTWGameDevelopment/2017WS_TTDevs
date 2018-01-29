using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeps : MonoBehaviour
{

    public float health;
    public float speed;
    public int creepType;
    public int reward;
    public float fireRes;
    public float windRes;
    public float iceRes;




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

    public float getFireRes()
    {
        return fireRes;
    }

    public float getWindRes()
    {
        return windRes;
    }

    public float getIceRes()
    {
        return iceRes;
    }

    public float getSpeed()
    {
        return speed;
    }

    public float getHealth()
    {
        return health;
    }

    public int getReward()
    {
        return reward;
    }

    public void setFireRes(float value)
    {
        fireRes = value;
    }

    public void setWindRes(float value)
    {
        windRes = value;
    }

    public void setIceRes(float value)
    {
        iceRes = value;
    }

    public void setReward(int value)
    {
        reward = value;
    }

    public void setSpeed(float value)
    {
        speed = value;
    }


    public void setHealth(float value)
    {
        health = value;
    }

    public void checkDmg(float dmg,int dmgType)
    {
        
        switch (dmgType)
        {
            case 1:
                if (fireRes>=1)
                {
                    takeDmg(0);
                }

                if (fireRes<=0)
                {
                    takeDmg(dmg);
                }
                takeDmg(dmg*(1-fireRes));
                break;
            case 2:
                if (windRes >= 1)
                {
                    takeDmg(0);
                }

                if (windRes <= 0)
                {
                    takeDmg(dmg);
                }
                takeDmg(dmg * (1 - windRes));
                break;
            case 3:
                if (iceRes >= 1)
                {
                    takeDmg(0);
                }

                if (iceRes <= 0)
                {
                    takeDmg(dmg);
                }
                takeDmg(dmg * (1 - iceRes));
                break;
            default:
                takeDmg(dmg);
                break;
        }




    }

    public void takeDmg(float value)
    {
        health -= value;
        Debug.Log("Health: " + health + "    Dmg: " + value);
    }
}

