using System.Collections;
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
    public GameObject rangeIndicator;
    private GameObject range;


    private GameObject turret;

    void Update()
    {
        if (Upgrade.single.getSelectedTurret() != turret || Upgrade.single.getSelectedTurret() == null)
        {
            Destroy(range);
        }

    }
    void Start()
    {
        upgrade = Upgrade.single;
        towerManager = TowerManager.single;
        r = GetComponent<Renderer>();
        old = r.material.color;
    }
    // makes the platform ract if u have a turret to build selected so u get visual feedback where u can build    
    void OnMouseEnter()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

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
    // Either Builds the selected Turret to build or if there is already a turret on this platform selects that one and shows its range
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Time.timeScale == 0)
        {
            return;
        }

        if (turret != null)
        {
            if (Upgrade.single.getSelectedTurret() != turret)
            {
                Vector3 spawnpoint = transform.position;
                spawnpoint.y -= 0.1f;
                range = (GameObject)Instantiate(rangeIndicator, spawnpoint, transform.rotation);
                range.gameObject.transform.localScale += new Vector3(turret.GetComponent<towers>().getRange() * 2.0f, 0, turret.GetComponent<towers>().getRange() * 2.0f);
            }
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
