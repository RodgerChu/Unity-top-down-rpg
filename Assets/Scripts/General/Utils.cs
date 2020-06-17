using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : Singleton<Utils>
{
    public static bool isPlayer(GameObject gameObject)
    {
        return gameObject.tag == "Player";
    }
}
