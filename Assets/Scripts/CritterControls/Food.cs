using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    float maxFood; 
    public float foodAmount;
    public float sustenance;

    public float growRate;

    Material mat;

	void Awake () {
        mat = GetComponent<Material>();
        string tag = this.tag;
        if(tag == "Tree")
        {
            sustenance = 1.5f;
            maxFood = 100f;
            foodAmount = 100f;
            growRate = 1f;
        }
        else if (tag == "Bush")
        {
            sustenance = 0.6f;
            maxFood = 50f;
            foodAmount = 50f;
            growRate = 2f;
        }
	}

    private void Update()
    {
        GrowFood();
        UpdateColor();
    }

    void UpdateColor()
    {
        // will use this to change the color based on the ratio of maxFood vs foodAmount
    }

    IEnumerator GrowFood()
    {
        while(true)
        {
            Debug.Log("growning food");
            foodAmount += growRate;
            yield return new WaitForSeconds(10f);
        }
    }
}
