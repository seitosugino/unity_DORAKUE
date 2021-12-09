using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowBattleMenuCommand : MonoBehaviour
{
    [SerializeField] Transform arrow = default;
    [SerializeField] List<SelectableText> selectableTexts = new List<SelectableText>();

    [SerializeField] SelectableText SelectableTextPrefab = default;

    public int currentID;

    public void CreateSelectableText(string[] commands)
    {
        arrow.SetParent(transform);
        foreach (SelectableText selectableText in selectableTexts)
        {
            Destroy(selectableText.gameObject);
        }
        selectableTexts.Clear();
        foreach (string command in commands)
        {
            Debug.Log(command);
            SelectableText text = Instantiate(SelectableTextPrefab, transform);
            text.SetText(command);
            selectableTexts.Add(text);
        }
    }

    void SetMoveArrowFunction()
    {
        foreach (SelectableText selectableText in selectableTexts)
        {
            selectableText.OnSelectAction = MoveArrowTo;
        }

        EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
    }
    public void MoveArrowTo(Transform parent)
    {
        arrow.SetParent(parent);
        currentID = parent.GetSiblingIndex();
        Debug.Log($"カーソル移動:currentID{currentID}");
    }

    public void Select()
    {
        EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
    }

    public void Open()
    {
        currentID = 0;
        gameObject.SetActive(true);
        SetMoveArrowFunction();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
