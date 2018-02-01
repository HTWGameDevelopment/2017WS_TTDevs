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
    private bool nextwave = false;

    private GameObject creep;

    // Use this for initialization
    void Start() {
		StartCoroutine(readLevel(PlayerPrefs.GetString("level")));
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(1))
        {
            TowerManager.single.selectTurret(-1);
        }

    }

    public void nextWave()
    {
        button.gameObject.SetActive(false);
        nextwave = true;
    }

    IEnumerator readLevel(string filename)
    {
        int waveCounter = 1;
        GameObject[] creeps;
        using (StreamReader sr = new StreamReader(filename))
        {
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

                creeps = GameObject.FindGameObjectsWithTag(creepTag);
                while (creeps != null && creeps.Length != 0)
                {
                    yield return new WaitForSeconds(0.5f);
                    Array.Clear(creeps, 0, creeps.Length);
                    creeps = GameObject.FindGameObjectsWithTag(creepTag);
                }
                showHealth.single.setWaveInformation("\nWave: " + waveCounter.ToString() +
                                                     "\n\nCreepType: " + type.ToString() +
                                                     "\nHealth: " + health.ToString() +
                                                     "\nSpeed: " + speed.ToString() +
                                                     "\nFireRes: " + fireRes.ToString() + "%" +
                                                     "\nWindRes: " + windRes.ToString() + "%" +
                                                     "\nIceRes: " + iceRes.ToString() + "%"
                                                     , amount);
                waveCounter++;
                PlayerStats.single.updateMoney(waveReward);
                PlayerStats.single.resetDestroyedCreeps();
                button.gameObject.SetActive(true);
                while (!nextwave)
                {
                    yield return new WaitForSeconds(0.5f);
                }
                Debug.Log("next Wave");
                nextwave = false;
                yield return new WaitForSeconds(.5f);
                StartCoroutine(spawnThem(type, amount, health, speed,reward,fireRes/100,windRes/100,iceRes/100));
                yield return new WaitForSeconds(0.5f);
                line = sr.ReadLine();

            }
            sr.Close();
        }

        creeps = GameObject.FindGameObjectsWithTag(creepTag);
        while (creeps != null && creeps.Length != 0)
        {
            yield return new WaitForSeconds(0.5f);
            Array.Clear(creeps, 0, creeps.Length);
            creeps = GameObject.FindGameObjectsWithTag(creepTag);
        }

        if (PlayerStats.single.getHealth() > 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelWon");
        }
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
