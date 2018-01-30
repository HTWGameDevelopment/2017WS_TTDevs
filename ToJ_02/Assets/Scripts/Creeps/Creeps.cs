using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeps : MonoBehaviour
{
    public static float SLOWDURATION = 5.0f;
    public static float WEAKENDURATION = 10.0f;
    public float health;
    public float speed;
    public int creepType;
    public int reward;
    public float fireRes;
    public float windRes;
    public float iceRes;


    public bool slowed = false;
    private Coroutine sCoroutine = null;
    private float weakenDuration = 0.0f;
    public bool weakened = false;
    private float slowDuration = 0.0f;
    private Coroutine wCoroutine = null;



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
        float realSpeed = speed;
        if (slowed)
        {
            realSpeed /= (2.0f - iceRes);
        }
        return realSpeed;
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
                if (fireRes >= 1.0f)
                {
                    takeDmg(0.0f);
                }
                else
                {

                    if (fireRes <= 0.0f)
                    {
                        takeDmg(dmg);
                    }
                    else
                    {
                        takeDmg(dmg * (1.0f - fireRes));
                    }
                }
                break;
            case 2:
                if (windRes >= 1.0f)
                {
                    takeDmg(0.0f);
                }
                else
                {

                    if (windRes <= 0.0f)
                    {
                        takeDmg(dmg);
                        weakenDuration = WEAKENDURATION;
                        if (wCoroutine == null)
                        {
                            wCoroutine = StartCoroutine(Weak(weakenDuration));
                        }
                        else
                        {
                            StopCoroutine(wCoroutine);
                            wCoroutine = StartCoroutine(Weak(weakenDuration));
                        }
                    }
                    else
                    {
                        takeDmg(dmg * (1.0f - windRes));
                        weakenDuration = WEAKENDURATION * (1.0f - windRes);
                        if (wCoroutine == null)
                        {
                            wCoroutine = StartCoroutine(Weak(weakenDuration));
                        }
                        else
                        {
                            StopCoroutine(wCoroutine);
                            wCoroutine = StartCoroutine(Weak(weakenDuration));
                        }
                    }
                }
                break;
            case 3:
                if (iceRes >= 1)
                {
                    takeDmg(0);
                }
                else
                {

                    if (iceRes <= 0)
                    {
                        takeDmg(dmg);
                        slowDuration = SLOWDURATION;
                        if (sCoroutine == null)
                        {
                            sCoroutine = StartCoroutine(Slow(slowDuration));
                        }
                        else
                        {
                            StopCoroutine(sCoroutine);
                            sCoroutine = StartCoroutine(Slow(slowDuration));
                        }
                    }
                    else
                    {
                        takeDmg(dmg * (1.0f - iceRes));
                        slowDuration = SLOWDURATION * (1.0f - iceRes);
                        if (sCoroutine == null)
                        {
                            sCoroutine = StartCoroutine(Slow(slowDuration));
                        }
                        else
                        {
                            StopCoroutine(sCoroutine);
                            sCoroutine = StartCoroutine(Slow(slowDuration));
                        }
                    }
                }
                break;
            default:
                takeDmg(dmg);
                break;
        }




    }

    private IEnumerator Slow(float time)
    {
        slowed = true;
        Debug.Log("slowed");
        yield return new WaitForSeconds(time);
        Debug.Log("not slowed");
        slowed = false;
        sCoroutine = null;
    }

    private IEnumerator Weak(float time)
    {
        weakened = true;
        Debug.Log("weakened");
        yield return new WaitForSeconds(time);
        Debug.Log("not weakened");
        weakened = false;
        wCoroutine = null;
    }

    private void takeDmg(float value)
    {
        if (weakened)
        {
           value *= (2.0f - windRes);
        }
        health -= value;
        Debug.Log("Health: " + health + "    Dmg: " + value);
    }
}

