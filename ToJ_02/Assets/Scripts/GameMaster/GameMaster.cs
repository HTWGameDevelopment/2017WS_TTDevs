using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameMaster : MonoBehaviour {
    public GameObject sphereCreep;
    public GameObject cubeCreep;
    public GameObject cylinderCreep;
    public Transform spawnPoint;

    private GameObject creep;

    // Use this for initialization
    void Start() {
        StartCoroutine(readLevel("Levels/TestFile.txt"));

    }

    // Update is called once per frame
    void Update() {


    }

    IEnumerator readLevel(string filename)
    {
        using (StreamReader sr = new StreamReader(filename))
        {
            string line = sr.ReadLine();

            while (line != null)
            {
                line = sr.ReadLine();
                String[] substrings = line.Split(':'); 
                int type;
                int amount;
                int health;
                int speed;
                int reward;
                int waveReward;
                Int32.TryParse(substrings[0], out type);
                Int32.TryParse(substrings[1], out amount);
                Int32.TryParse(substrings[2], out health);
                Int32.TryParse(substrings[3], out speed);
                Int32.TryParse(substrings[4], out reward);
                Int32.TryParse(substrings[5], out waveReward);
                PlayerStats.single.updateMoney(waveReward);
                StartCoroutine(spawnThem(type, amount, health, speed,reward));
                yield return new WaitForSeconds(20f);

            }
            sr.Close();

        }
    }




    

    void printArray(String[] array)
    {
        for (int i = 0; i <= array.Length - 1; i++)
        {
            print(array[i]);
        }
    }

    IEnumerator spawnThem(int type, int amount, int health, float speed,int reward)
    {
        switch (type)
        {
            case 1:
                for (int i = 0; i <= amount; i++)
                {
                    creep = (GameObject)Instantiate(sphereCreep, spawnPoint.position, spawnPoint.rotation);
                    Creeps stats = creep.GetComponent<Creeps>();
                    stats.setHealth(health);
                    stats.setSpeed(speed);
                    stats.setValue(reward);
                    yield return new WaitForSeconds(0.5f);
                }
                break;

            case 2:
                for (int i = 0; i <= amount; i++)
                {
                    creep = (GameObject)Instantiate(cubeCreep, spawnPoint.position, spawnPoint.rotation);
                    Creeps stats = creep.GetComponent<Creeps>();
                    stats.setHealth(health);
                    stats.setSpeed(speed);
                    stats.setValue(reward);

                    yield return new WaitForSeconds(0.5f);
                }
                break;

            case 3:
                for (int i = 0; i <= amount; i++)
                {
                    creep = (GameObject)Instantiate(cylinderCreep, spawnPoint.position, spawnPoint.rotation);
                    Creeps stats = creep.GetComponent<Creeps>();
                    stats.setHealth(health);
                    stats.setSpeed(speed);
                    stats.setValue(reward);

                    yield return new WaitForSeconds(0.5f);
                }
                break;
            default:
                break;
        }
    }
}
