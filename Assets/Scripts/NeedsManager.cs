using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsManager : MonoBehaviour {

    public float hunger = 100f;

    Critter critter;
    Wander wander;
    MoveToTarget mtt;
    Food source;

    bool feeding = false;
    bool setTarget = false;

    float feedFactor;

    GameObject foodSource;

    private void Awake()
    {
        critter = GetComponent<Critter>();
        wander = GetComponent<Wander>();
        mtt = GetComponent<MoveToTarget>();

        wander.speed = critter.speed;
    }
    
	void Update ()
    {
        CheckHunger();	
	}

    void CheckHunger()
    {
        if (!feeding)
        {
            hunger -= Time.deltaTime * critter.hungerFactor;

            if (hunger < 80)
            {
                FindFood();
            }
        }
        else
        {
            hunger += Time.deltaTime * feedFactor;
            source.foodAmount -= Time.deltaTime * critter.eatRate;
            if(hunger >= 100)
            {
                feeding = false;
                wander.enabled = true;
                mtt.atTarget = false;
                mtt.enabled = false;
                setTarget = false;
            }
        }
    }

    void FindFood()
    {
        if(!setTarget)
        {
            GameObject[] foodSources = GameObject.FindGameObjectsWithTag(critter.diet);

            float min = 0;
            float temp;
            foreach (GameObject foodsource in foodSources)
            {
                temp = Vector3.Distance(transform.position, foodsource.transform.position);
                if (min == 0 || temp < min)
                {
                    min = temp;
                    foodSource = foodsource;
                }
            }
            source = foodSource.GetComponent<Food>();
            feedFactor = source.sustenance;
            wander.enabled = false;
            mtt.target = foodSource.transform.position;
            mtt.speed = critter.speed;
            mtt.enabled = true;
            setTarget = true;
        }

        if(mtt.enabled)
        {
            if(mtt.atTarget)
            {
                if(source.foodAmount <= 0)
                {
                    source.tag = "depleted";
                    setTarget = false;
                }
                else
                {
                    feeding = true;
                }
            }
        }
    }
}
