using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }

[System.Serializable]
public class MouseEvent : UnityEvent<ClickData> { }

public class MouseManager : MonoBehaviour
{
    private GameObject clickedObject;
    private int numOfClicks = 0;
    private float clicktime = 0;
    private float clickdelay = 0.5f;
    private bool clickedLMB = false;

    private Vector3 clickedPos;

    public event Action<ClickData> mouseEvent;

    public LayerMask clickableLayer;

    public Texture2D pointer; // standart cursor
    public Texture2D target; // clickable 
    public Texture2D doorway; // doors
    public Texture2D resources;

    public EventVector3 onClickEnvironment;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 30, clickableLayer.value))
        {
            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, Vector2.zero, CursorMode.Auto);
            }
            else if (hit.collider.gameObject.tag == "MineableOre" || hit.collider.gameObject.tag == "Pickaxe")
            {
                Cursor.SetCursor(resources, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(target, Vector2.zero, CursorMode.Auto);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (numOfClicks != 0 && !clickedLMB)
                {
                    numOfClicks = 1;
                }
                else
                {
                    numOfClicks++;
                }

                clickedPos = hit.point;
                clickedObject = hit.collider.gameObject;
                
                clickedLMB = true;
                clicktime = Time.time;
            }
            else if (Input.GetMouseButtonDown(1)) 
            {
                clicktime = Time.time;
                if (numOfClicks != 0 && clickedLMB)
                {
                    numOfClicks = 1;
                }
                else
                {
                    numOfClicks++;
                }

                clickedLMB = false;
                clickedPos = hit.point;
                clickedObject = hit.collider.gameObject;

                clicktime = Time.time;
            }
        }
        else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }

        if ((Time.time - clicktime > 0.5 && numOfClicks != 0) || numOfClicks >= 2)
        {
            SendMouseClickedEvent();
        }

    }

    void SendMouseClickedEvent()
    {
        mouseEvent(new ClickData(clickedLMB, clickedPos, numOfClicks, clickedObject));

        numOfClicks = 0;
        clickedPos = Vector3.zero;
    }
}
