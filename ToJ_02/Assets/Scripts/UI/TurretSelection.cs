using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretSelection : MonoBehaviour,IPointerDownHandler {

    private TowerManager towerManager;
    private PlayerStats playerStats;
    void Start()
    {
        playerStats = PlayerStats.single;
        towerManager = TowerManager.single;
    }
    public void SelectTurretOne()
    {
        towerManager.selectTurret(0);
        if (!(playerStats.enoughMoney((int)towerManager.getSelectedTurretPrice())))
        {
            towerManager.selectTurret(-1);
            Debug.Log("No Money");
        }
        
    }

    public void SelectTurretTwo()
    {
        towerManager.selectTurret(1);
        if (!(playerStats.enoughMoney((int)towerManager.getSelectedTurretPrice())))
        {
            towerManager.selectTurret(-1);
            Debug.Log("No Money");
        }

    }

    public void SelectTurretThree()
    {
        towerManager.selectTurret(2);
        if (!(playerStats.enoughMoney((int)towerManager.getSelectedTurretPrice())))
        {
            towerManager.selectTurret(-1);
            Debug.Log("No Money");
        }

    }
    public void SelectTurretFour()
    {
        towerManager.selectTurret(3);
        if (!(playerStats.enoughMoney((int)towerManager.getSelectedTurretPrice())))
        {
            towerManager.selectTurret(-1);
            Debug.Log("No Money");
        }

    }

    public void SelectTurretFive()
    {
        towerManager.selectTurret(4);
        if (!(playerStats.enoughMoney((int)towerManager.getSelectedTurretPrice())))
        {
            towerManager.selectTurret(-1);
            Debug.Log("No Money");
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        towerManager.selectTurret(-1);
    }


}
