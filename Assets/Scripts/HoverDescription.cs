using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string itemName;
    private string description;

    public void Initialize(string name, string desc)
    {
        itemName = name;
        description = desc;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetText();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DescriptionPanel.Instance.SetDefaultText();
    }

    private void SetText()
    {
        string a = itemName + " - " + description;
        DescriptionPanel.Instance.SetText(a);
    }
}
