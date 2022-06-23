using System;
using UnityEngine;
using Zenject;
using UniRx;

public class CubeSelectorPresenter : MonoBehaviour
{
    [Inject]
    private IObservable<ISelectable> _selectedValue;

    private ISelectable _activeSelectabeObject;

    public void Start()
    {
        _selectedValue.Subscribe(OnSelected);
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
