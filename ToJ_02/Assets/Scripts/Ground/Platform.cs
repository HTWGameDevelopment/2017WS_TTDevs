using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private Renderer r;
    public Color mouseOver;
    private Color old;


    private GameObject turret;

    void Start()
    {
        r = GetComponent<Renderer>();
        old = r.material.color;
    }
        
    void OnMouseEnter()
    {
        r.material.color = mouseOver;

    }
    void OnMouseExit()
    {
        r.material.color = old;
    }

}
