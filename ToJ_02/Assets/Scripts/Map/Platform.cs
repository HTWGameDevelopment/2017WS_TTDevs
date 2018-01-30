﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Platform : MonoBehaviour {

    public Color mouseOver;
    private Upgrade upgrade;
    private Renderer r;
    private Color old;
    public Vector3 buildOfSet;
    private TowerManager towerManager;


    private GameObject turret;

    void Start()
    {
        upgrade = Upgrade.single;
        towerManager = TowerManager.single;
        r = GetComponent<Renderer>();
        old = r.material.color;
    }
        
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (towerManager.getSelectedTurretPrefab() == null)
        {
            return;
        }

        r.material.color = mouseOver;

    }
    void OnMouseExit()
    {
        r.material.color = old;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            upgrade.selectTurret(turret);
            towerManager.deselect();
            return;
        }

        if (towerManager.getSelectedTurretPrefab() == null)
        {
            return;
        }

        GameObject selectedTurret = towerManager.getSelectedTurretPrefab();
        turret = (GameObject)Instantiate(selectedTurret, transform.position + buildOfSet, transform.rotation);
        towers tower = turret.GetComponent<towers>();
        tower.range = towerManager.getSelectedTurretRange();
        tower.dmg = towerManager.getSelectedTurretDmg();
        tower.spd = towerManager.getSelectedTurretSpd();
        tower.price = towerManager.getSelectedTurretPrice();
        tower.element = (int)towerManager.getSelectedTurretElement();
        tower.type = (int)towerManager.getSelectedTurretType();
        PlayerStats.single.updateMoney(-(int)tower.price);
        towerManager.selectTurret(-1);
    }

}
