using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDResourceCell : MonoBehaviour
{
    public Image resourceIcon;
    public TextMeshProUGUI amountText;

    public void SetAmount(int amount)
    {        
        amountText.text = amount.ToString();
    }
    
}
