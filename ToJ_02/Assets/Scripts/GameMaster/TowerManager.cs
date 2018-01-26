﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TowerManager : MonoBehaviour {
    public static TowerManager single;
    void Awake()
    {
        single = this;
    }
    public static float BASECOST = 100;
    public static float GENERATORCOST = 50;
    public static float RANGECOST = 25;
    public static float DMGCOST = 10;
    public static float SPDCOST = 20;
    public static float RANGEENERGIE = 25;
    public static float DMGENERGIE = 10;
    public static float SPDENERGIE = 20;
    public static float BASESLOTS = 2;
    public static float GENERATORENERGIE = 150;
    public static float ACTIVEENERGIE = 200;
    public static float ACTIVECOST = 500;


    public GameObject smallSingleTargetPrefab;
    // Other TurretObtions

    private float[,] turretsToSelect = new float[5,7];//[x,y] x = Turrets 1-5 y0= turretType y1 = turretRange y2 = turretDmg y3 = turretSpd y4 = turret cost y5 = element y6 = active
    public int selectedTurret = 0;

    void Start()
    {
        readTurretInfo("Towers/Turrets.txt");
        
    }

    public GameObject getSelectedTurretPrefab()
    {
        int cases = (int)turretsToSelect[selectedTurret, 0];
        switch (cases)
        {
            case 1:
                return smallSingleTargetPrefab;
            default:
                return smallSingleTargetPrefab;
        }
    }

    public float getSelectedTurretRange()
    {
        return turretsToSelect[selectedTurret,1];
    }

    public float getSelectedTurretDmg()
    {
        return turretsToSelect[selectedTurret,2];
    }

    public float getSelectedTurretSpd()
    {
        return turretsToSelect[selectedTurret,3];
    }

    public float getSelectedTurretPrice()
    {
        return turretsToSelect[selectedTurret, 4];
    }

    public float getSelectedTurretElement()
    {
        return turretsToSelect[selectedTurret, 5];
    }

    public float getSelectedTurretActive()
    {
        return turretsToSelect[selectedTurret, 6];
    }


    private void readTurretInfo(string filename)
    {
        using (StreamReader sr = new StreamReader(filename))
        {
            string line = sr.ReadLine();

            for(int i = 0; i <= 4; i++)
            {
                int[] read = new int[11];
                float price;
                line = sr.ReadLine();
                String[] substrings = line.Split(':');
                for (int j = 0; j < read.Length; j++)
                {
                    Int32.TryParse(substrings[j], out read[j]);
                }
                float maxEnergie = GENERATORENERGIE * read[2];
                float maxSlots = BASESLOTS * read[1];
                float usedEnergie = RANGEENERGIE * read[4] * read[5] + DMGENERGIE * read[6] * read[7] + SPDENERGIE * read[8] * read[9] + ACTIVEENERGIE * read[10];
                float usedSlots = read[5] + read[7] + read[9];

                Debug.Log("maxEnergie: " + maxEnergie + "   usedEnergie: " + usedEnergie +  "   maxSlots: " + maxSlots + "   usedSlots: " + usedSlots );
                turretsToSelect[i, 0] = read[0];
                turretsToSelect[i, 1] = generateStat(read[4],read[5],2) + 8/read[0];
                turretsToSelect[i, 2] = generateStat(read[6],read[7],4);
                turretsToSelect[i, 3] = generateStat(read[8],read[9],0.5f);
                price = BASECOST * read[1] + GENERATORCOST * read[2] + RANGECOST * read[4] * read[5] + DMGCOST * read[6] * read[7] + SPDCOST * read[8] * read[9] + ACTIVECOST * read[10];
                turretsToSelect[i, 4] = price*read[0]*read[3];
                turretsToSelect[i, 5] = read[3];
                turretsToSelect[i, 6] = read[10];
            }
            sr.Close();

        }
    }

    private float generateStat(float boostType, float amount, float multiplier)
    {
        float stat = boostType * amount * multiplier;
        if (stat == 0)
        {
            return 0.5f*multiplier;
        }
        return stat;
    }



}
