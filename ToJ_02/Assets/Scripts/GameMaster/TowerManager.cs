using System.Collections;
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

    public GameObject smallSingleTargetPrefab;
    // Other TurretObtions

    private int[,] turretsToSelect = new int[5,4];
    public int selectedTurret = 0;

    void Start()
    {
        readTurretInfo("Towers/Turrets.txt");
        
    }

    public GameObject getSelectedTurretPrefab()
    {
        switch (turretsToSelect[selectedTurret,0])
        {
            case 1:
                return smallSingleTargetPrefab;
            default:
                return smallSingleTargetPrefab;
        }
    }

    public int getSelectedTurretRange()
    {
        return turretsToSelect[selectedTurret,1];
    }

    public int getSelectedTurretDmg()
    {
        return turretsToSelect[selectedTurret,2];
    }

    public int getSelectedTurretSpd()
    {
        return turretsToSelect[selectedTurret,3];
    }

    private void readTurretInfo(string filename)
    {
        using (StreamReader sr = new StreamReader(filename))
        {
            string line = "";

            for(int i = 0; i <= 4; i++)
            {
                line = sr.ReadLine();
                String[] substrings = line.Split(':');
                Int32.TryParse(substrings[0], out turretsToSelect[i, 0]);
                Int32.TryParse(substrings[1], out turretsToSelect[i, 1]);
                Int32.TryParse(substrings[2], out turretsToSelect[i, 2]);
                Int32.TryParse(substrings[3], out turretsToSelect[i, 3]);
                
            }
            sr.Close();

        }
    }
}
