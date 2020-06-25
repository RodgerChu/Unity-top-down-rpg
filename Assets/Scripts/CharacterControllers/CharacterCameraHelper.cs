using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameraHelper : MonoBehaviour
{
    public Transform setTo;

    // Update is called once per frame
    void Update()
    {
        transform.position = setTo.position;
    }
}
