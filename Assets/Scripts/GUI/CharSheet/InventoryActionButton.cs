using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class InventoryActionButton : MonoBehaviour, IPointerClickHandler
{

    public TextMeshProUGUI textMesh;
    public Image underline;

    public Color hoveredColor = new Color(252, 225, 49);
    public Color defaultColor = Color.white;

    public Action onClickAction;

    private void OnMouseOver()
    {
        Debug.Log("on mouse over");
        textMesh.color = hoveredColor;
        underline.color = hoveredColor;
    }

    private void OnMouseExit()
    {
        Debug.Log("on mouse exit");
        textMesh.color = defaultColor;
        underline.color = defaultColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onClickAction?.Invoke();
        }
        
    }
}
