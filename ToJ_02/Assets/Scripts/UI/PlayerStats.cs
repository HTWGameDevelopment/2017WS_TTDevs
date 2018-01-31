using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats single;
    void Awake()
    {
        single = this;
    }
    public int health = 100;
    private int money = 0;
    private int destroyedCreeps = 0;
    private int allDestruction;

    public Text cash;

	// Use this for initialization
	void Start () {
        updateMoney(0);
	}
	
	// Update is called once per frame
	void Update () {
        //print (health);
		if (health <= 0) {
			Debug.Log ("Game Over");
			UnityEditor.SceneManagement.EditorSceneManager.LoadScene ("LevelLost");
		} else if (health > 0 && allDestruction == GameMaster.supposedCreeps) {
			UnityEditor.SceneManagement.EditorSceneManager.LoadScene ("LevelWon");
		}
	}

	public void reduceHealth(int amount) {
		health = health - amount;
	}

	public int getHealth() {
		return health;
	}

    public int getMoney()
    {
        return money;
    }

    public bool enoughMoney(int price)
    {
        if (money - price < 0)
        {
            return false;
        }

        return true;
    }

    public void updateMoney(int value)
    {
        money += value;
        cash.text = "\n Cash: " + money.ToString();
    }

    public void creepDestroyed()
    {
        destroyedCreeps++;
        allDestruction++;
    }

    public int getDestroyedCreeps()
    {
        return destroyedCreeps;
    }
    public void resetDestroyedCreeps()
    {
        destroyedCreeps = 0;
    }

	public int getAllDestruction() {
		return allDestruction;
	}
}
