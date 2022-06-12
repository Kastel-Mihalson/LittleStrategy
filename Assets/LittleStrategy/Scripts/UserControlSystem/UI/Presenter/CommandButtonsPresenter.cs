using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField]
    private SelectableValue _selectableValue;

    [SerializeField]
    private CommandButtonsView _view;

    [Inject]
    private CommandButtonsModel _model;

    private ISelectable _currentSelectable;

    void Start()
    {
        _view.OnClick += _model.OnCommandButtonClicked;

        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteractions;

        _selectableValue.OnNewValue += OnSelect;

        OnSelect(_selectableValue.CurrentValue);
    }

    private void OnSelect(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        if (_currentSelectable != null)
        {
            _model.OnSelectionChanged();
        }

        _currentSelectable = selectable;
        _view.Clear();

        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();

            commandExecutors
                .AddRange((selectable as Component)
                .GetComponentsInParent<ICommandExecutor>());

            _view.MakeLayout(commandExecutors);
        }
    }
}
