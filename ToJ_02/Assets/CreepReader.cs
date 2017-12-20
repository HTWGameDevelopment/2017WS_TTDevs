using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class CreepReader : MonoBehaviour {
    public Transform sphereCreep;
    public Transform cubeCreep;
    public Transform cylinderCreep;
    public Transform spawnPoint;



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
            string line = "";

            while (line != null)
            {
                line = sr.ReadLine();
                String[] substrings = line.Split(':'); 
                //printArray(substrings);
                int type;
                int amount;
                Int32.TryParse(substrings[0], out type);
                Int32.TryParse(substrings[1], out amount);
                StartCoroutine(spawnThem(type, amount, 0, 0));
                yield return new WaitForSeconds(4f);

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

    IEnumerator spawnThem(int type, int amount, int health, float speed)
    {
        switch (type)
        {
            case 0:
                for (int i = 0; i <= amount; i++)
                {
                    Instantiate(sphereCreep, spawnPoint.position, spawnPoint.rotation);
                    yield return new WaitForSeconds(0.2f);
                }
                break;

            case 1:
                for (int i = 0; i <= amount; i++)
                {
                    Instantiate(cubeCreep, spawnPoint.position, spawnPoint.rotation);
                    yield return new WaitForSeconds(0.2f);
                }
                break;

            case 2:
                for (int i = 0; i <= amount; i++)
                {
                    Instantiate(cylinderCreep, spawnPoint.position, spawnPoint.rotation);
                    yield return new WaitForSeconds(0.2f);
                }
                break;
        }
    }
}
