using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform sphereCreep;
    public Transform spawnPoint;
    public Transform cubeCreep;
    public Transform cylinderCreep;
    public float waveTime = 0f;

    // Use this for initialization
    void Start()
    {
 //       print("first wave in 5 seconds!");


    }

    // Update is called once per frame
    void Update()
    {
        //if (waveTime <= 0f)
        //{
          //  StartCoroutine(spawnCreeps());
            //waveTime = 5f;
        //}
        //else
        //{
          //  waveTime -= Time.deltaTime;
        //}

    }

 //   IEnumerator spawnCreeps()
 //   {
//
  //      for (int i = 0; i <= 10; i++)
 //       {
 //           spawnCreep();
 //           yield return new WaitForSeconds(0.3f);
 //           

 //     }
 //   }

 //   void spawnCreep()
 //   {
 //       Instantiate(sphereCreep, spawnPoint.position, spawnPoint.rotation);
 //   }
}
