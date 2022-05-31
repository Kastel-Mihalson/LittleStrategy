using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField]
    private SelectableValue _selectableValue;
    [SerializeField]
    private CommandButtonsView _view;
    [SerializeField]
    private AssetsContext _context;

    private ISelectable _currentSelectable;

    void Start()
    {
        _selectableValue.OnSelected += OnSelect;
        OnSelect(_selectableValue.CurrentValue);
        _view.onClick += OnButtonClick;
    }

    private void OnSelect(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }

        _currentSelectable = selectable;
        _view.Clear();

        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }

    private void OnButtonClick(ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;

        if (unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
            return;
        }

        throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClick)}:" +
            $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
    }
}
