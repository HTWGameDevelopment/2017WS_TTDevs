using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretSelection : MonoBehaviour,IPointerDownHandler {


    void Start()
    {

    }
    public void SelectTurretOne()
    {
        TowerManager.single.selectTurret(0);
    }

    public void SelectTurretTwo()
    {
        TowerManager.single.selectTurret(1);
    }

    public void SelectTurretThree()
    {
        TowerManager.single.selectTurret(2);
    }

    public void SelectTurretFour()
    {
        TowerManager.single.selectTurret(3);
    }

    public void SelectTurretFive()
    {
        TowerManager.single.selectTurret(4);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TowerManager.single.selectTurret(-1);
    }


}
