using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowText : Selectable
{
    public string text;
    public Text uiText;

    BaseEventData m_BaseEvent;

    void Update()
    {
        //Check if the GameObject is being highlighted
        if (IsHighlighted() == true)
        {
            uiText.text=text;
            Debug.Log("Selectable is Highlighted");
        }
    }
}
