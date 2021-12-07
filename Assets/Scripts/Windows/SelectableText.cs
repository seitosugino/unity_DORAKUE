using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectableText : Selectable
{
    public UnityAction<Transform> OnSelectAction = null;

    public override void OnSelect(BaseEventData eventData)
    {
        Debug.Log($"{gameObject.name}");
        OnSelectAction.Invoke(transform);
    }
    public override void OnDeselect(BaseEventData eventData)
    {
        Debug.Log($"{gameObject.name}");
    }
}