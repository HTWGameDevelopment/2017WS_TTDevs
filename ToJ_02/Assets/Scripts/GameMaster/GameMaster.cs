using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
    public GameObject sphereCreep;
    public GameObject cubeCreep;
    public GameObject cylinderCreep;
    public Transform spawnPoint;
    public string creepTag = "Creep";
    public Button button;
    private bool nextwave = true;

    private GameObject creep;

    // Use this for initialization
    void Start() {
        StartCoroutine(readLevel("Levels/TestFile.txt"));

    }

    // Update is called once per frame
    void Update() {


    }

    public void nextWave()
    {
        button.gameObject.SetActive(false);
        nextwave = true;
    }

    IEnumerator readLevel(string filename)
    {
        using (StreamReader sr = new StreamReader(filename))
        {
            bool firstwave = true;
            string line = sr.ReadLine();
            line = sr.ReadLine();

            while (line != null)
            {
                String[] substrings = line.Split(':'); 
                int type;
                int amount;
                int health;
                int speed;
                int reward;
                int waveReward;
                float fireRes;
                float windRes;
                float iceRes;
                Int32.TryParse(substrings[0], out type);
                Int32.TryParse(substrings[1], out amount);
                Int32.TryParse(substrings[2], out health);
                Int32.TryParse(substrings[3], out speed);
                Int32.TryParse(substrings[4], out reward);
                Int32.TryParse(substrings[5], out waveReward);
                float.TryParse(substrings[6], out fireRes);
                float.TryParse(substrings[7], out windRes);
                float.TryParse(substrings[8], out iceRes);

                GameObject[] creeps = GameObject.FindGameObjectsWithTag(creepTag);
                while (creeps != null && creeps.Length != 0)
                {
                    yield return new WaitForSeconds(0.5f);
                    Array.Clear(creeps, 0, creeps.Length);
                    creeps = GameObject.FindGameObjectsWithTag(creepTag);
                }
                showHealth.single.setWaveInformation("\n\nCreepType: " + type.ToString() +
                                                     "\nHealth: " + health.ToString() +
                                                     "\nSpeed: " + speed.ToString() +
                                                     "\nFireRes: " + fireRes.ToString() + "%" +
                                                     "\nWindRes: " + windRes.ToString() + "%" +
                                                     "\nIceRes: " + iceRes.ToString() + "%"
                                                     , amount);
                PlayerStats.single.resetDestroyedCreeps();
                line = sr.ReadLine();
                if (!firstwave && line != null)
                {
                    button.gameObject.SetActive(true);
                }
                while (!nextwave && line != null)
                {
                    yield return new WaitForSeconds(0.5f);
                }
                Debug.Log("next Wave");
                nextwave = false;
                yield return new WaitForSeconds(.5f);
                PlayerStats.single.updateMoney(waveReward);
                StartCoroutine(spawnThem(type, amount, health, speed,reward,fireRes/100,windRes/100,iceRes/100));
                firstwave = false;
                yield return new WaitForSeconds(0.5f);
                
            }
            sr.Close();
        }
        Debug.Log("You Won");
        //ToDo Open End Game Screen
    }




    

    void printArray(String[] array)
    {
        for (int i = 0; i <= array.Length - 1; i++)
        {
            print(array[i]);
        }
    }

    IEnumerator spawnThem(int type, int amount, int health, float speed, int reward, float fireRes, float windRes,float iceRes)
    {
        switch (type)
        {
            case 1:
                for (int i = 0; i < amount; i++)
                {
                    creep = (GameObject)Instantiate(sphereCreep, spawnPoint.position, spawnPoint.rotation);
                    Creeps stats = creep.GetComponent<Creeps>();
                    stats.setHealth(health);
                    stats.setSpeed(speed);
                    stats.setReward(reward);
                    stats.setFireRes(fireRes);
                    stats.setWindRes(windRes);
                    stats.setIceRes(iceRes);
                    yield return new WaitForSeconds(0.5f);
                }
                break;

            case 2:
                for (int i = 0; i < amount; i++)
                {
                    creep = (GameObject)Instantiate(cubeCreep, spawnPoint.position, spawnPoint.rotation);
                    Creeps stats = creep.GetComponent<Creeps>();
                    stats.setHealth(health);
                    stats.setSpeed(speed);
                    stats.setReward(reward);
                    stats.setFireRes(fireRes);
                    stats.setWindRes(windRes);
                    stats.setIceRes(iceRes);
                    yield return new WaitForSeconds(0.5f);
                }
                break;

            case 3:
                for (int i = 0; i < amount; i++)
                {
                    creep = (GameObject)Instantiate(cylinderCreep, spawnPoint.position, spawnPoint.rotation);
                    Creeps stats = creep.GetComponent<Creeps>();
                    stats.setHealth(health);
                    stats.setSpeed(speed);
                    stats.setReward(reward);
                    stats.setFireRes(fireRes);
                    stats.setWindRes(windRes);
                    stats.setIceRes(iceRes);
                    yield return new WaitForSeconds(0.5f);
                }
                break;
            default:
                break;
        }
    }
}
