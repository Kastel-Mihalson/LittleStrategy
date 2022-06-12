using UnityEngine;

public class CubeSelectorPresenter : MonoBehaviour
{
    [SerializeField]
    private SelectableValue _selectableValue;

    private ISelectable _activeSelectabeObject;

    public void Start()
    {
        _selectableValue.OnNewValue += OnSelected;
        OnSelected(_selectableValue.CurrentValue);
    }

    private void OnSelected(ISelectable selected)
    {
        if (_activeSelectabeObject == selected)
        {
            return;
        }
        if (_activeSelectabeObject != null)
        {
            _activeSelectabeObject.UnsetSelected();
        }

        _activeSelectabeObject = selected;

        if (selected != null)
        {
            selected.SetSelected();
        }
    }
}
