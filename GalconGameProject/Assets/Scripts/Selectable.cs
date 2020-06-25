using UnityEngine;


public class Selectable : MonoBehaviour
{
    public enum SelectionState
    {
        Deselected,
        Selected
    }

    public SelectionState CurrentState { get; private set; }
    public GameObject SelectedEffectObject;
    public void Select()
    {
        CurrentState = SelectionState.Selected;
        SelectedEffectObject.SetActive(true);
    }

    public void Deselect()
    {
        CurrentState = SelectionState.Deselected;
        SelectedEffectObject.SetActive(false);
    }
}
