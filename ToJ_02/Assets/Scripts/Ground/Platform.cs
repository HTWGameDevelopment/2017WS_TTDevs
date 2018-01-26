using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour {

    private Renderer r;
    public Color mouseOver;
    private Color old;
    public Vector3 buildOfSet;


    private GameObject turret;

    void Start()
    {
        r = GetComponent<Renderer>();
        old = r.material.color;
    }
        
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (TowerManager.single.getSelectedTurretPrefab() == null)
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

        if (TowerManager.single.getSelectedTurretPrefab() == null)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("No Space");
            return;
        }

        GameObject selectedTurret = TowerManager.single.getSelectedTurretPrefab();
        turret = (GameObject)Instantiate(selectedTurret, transform.position + buildOfSet, transform.rotation);
        towers tower = turret.GetComponent<towers>();
        tower.range = TowerManager.single.getSelectedTurretRange();
        tower.dmg = TowerManager.single.getSelectedTurretDmg();
        tower.spd = TowerManager.single.getSelectedTurretSpd();
        tower.price = TowerManager.single.getSelectedTurretPrice();
        tower.element = TowerManager.single.getSelectedTurretElement();
        TowerManager.single.selectTurret(-1);
    }

}
