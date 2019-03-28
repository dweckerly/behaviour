using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critter : MonoBehaviour {

    public string diet;
    public string size;
    public float speed;
    public float eatRate;
    public float hungerFactor;

    private void Awake()
    {
        if(size == "small")
        {
            speed = 5;
            eatRate = 0.5f;
            hungerFactor = 0.5f;
        }
        else if(size == "medium")
        {
            speed = 4;
            eatRate = 1f;
            hungerFactor = 1f;
        }
        else if (size == "large")
        {
            speed = 3;
            eatRate = 1.5f;
            hungerFactor = 2f;
        }
    }
}
