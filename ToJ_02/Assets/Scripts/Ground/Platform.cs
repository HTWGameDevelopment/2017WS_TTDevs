using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour {

    private Renderer r;
    public Color mouseOver;
    private Color old;
    public Vector3 buildOfSet;
    private TowerManager towerManager;


    private GameObject turret;

    void Start()
    {
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

        if (towerManager.getSelectedTurretPrefab() == null)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("No Space");
            return;
        }

        GameObject selectedTurret = towerManager.getSelectedTurretPrefab();
        turret = (GameObject)Instantiate(selectedTurret, transform.position + buildOfSet, transform.rotation);
        towers tower = turret.GetComponent<towers>();
        tower.range = towerManager.getSelectedTurretRange();
        tower.dmg = towerManager.getSelectedTurretDmg();
        tower.spd = towerManager.getSelectedTurretSpd();
        tower.price = towerManager.getSelectedTurretPrice();
        tower.element = towerManager.getSelectedTurretElement();
        PlayerStats.single.updateMoney(-(int)tower.price);
        towerManager.selectTurret(-1);
    }

}
