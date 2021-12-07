using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBattleMenuCommand : MonoBehaviour
{
    [SerializeField] Transform arrow = default;
    [SerializeField] List<SelectableText> selectableTexts = new List<SelectableText>();
    private void Start()
    {
        SetMoveArrowFunction();
    }
    void SetMoveArrowFunction()
    {
        foreach (SelectableText selectableText in selectableTexts)
        {
            selectableText.OnSelectAction = MoveArrowTo;
        }
    }
    public void MoveArrowTo(Transform parent)
    {
        Debug.Log("カーソル移動");
        arrow.SetParent(parent);
    }
}
