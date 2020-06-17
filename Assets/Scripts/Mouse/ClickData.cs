using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickData
{
    public bool clickedLMB;
    public Vector3 clickArea;
    public int numOfClicks;
    public GameObject clickedObject;

    public ClickData(bool lmb, Vector3 area, int num, GameObject clickedObject)
    {
        clickedLMB = lmb;
        clickArea = area;
        numOfClicks = num;
        this.clickedObject = clickedObject;
    }
}
