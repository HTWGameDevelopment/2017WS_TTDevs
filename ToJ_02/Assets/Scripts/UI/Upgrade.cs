using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {

    public static Upgrade single;
    void Awake()
    {
        single = this;
    }

    public Text turretStats;
    private GameObject selectedTurret = null;
    private PlayerStats playerstats;
    
    void Start()
    {
        playerstats = PlayerStats.single;
    }


    public GameObject getSelectedTurret()
    {
        return selectedTurret;
    }

    public void selectTurret(GameObject turret)
    {
        selectedTurret = turret;
        enableButtons(true);
        updateText();
    }

    private void updateText()
    {
        turretStats.text = "Element: " + getElement(selectedTurret.GetComponent<towers>().getElement()) +
                            "\nDamage: " + selectedTurret.GetComponent<towers>().getDmg().ToString() +
                            "\nRange: " + selectedTurret.GetComponent<towers>().getRange().ToString() +
                            "\nAttack Speed: " + selectedTurret.GetComponent<towers>().getSpd().ToString() +
                            "\nFocus Type: " + getFocus(selectedTurret.GetComponent<towers>().getFocus()) +
                            "\nUpgrade Cost: " + ((int)(selectedTurret.GetComponent<towers>().getPrice() * 0.1f)).ToString();
    }

    private string getElement(int type)
    {
        switch (type)
        {
            case 1:
                return "fire";
            case 2:
                return "wind";
            case 3:
                return "ice";
            default:
                return "not yet Implemented";
        }
    }

    private string getFocus(int type)
    {
        switch (type)
        {
            case 1:
                return "near";
            case 2:
                return "first";
            case 3:
                return "last";
            default:
                return "not yet Implemented";
        }
    }

    public void deselect()
    {
        selectedTurret = null;
        enableButtons(false);
    }

    private void enableButtons(bool test)
    {
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(test);
        }

    }

    public void upgrade()
    {
        int price = (int)(selectedTurret.GetComponent<towers>().getPrice()*0.1f);
        if (playerstats.enoughMoney(price))
        {
            playerstats.updateMoney(-price);
            selectedTurret.GetComponent<towers>().upgrade();
            updateText();
        }
        
    }

    public void first()
    {
        selectedTurret.GetComponent<towers>().setFocus(2);
        updateText();
    }

    public void last()
    {
        selectedTurret.GetComponent<towers>().setFocus(3);
        updateText();
    }

    public void near()
    {
        selectedTurret.GetComponent<towers>().setFocus(1);
        updateText();
    }

}
