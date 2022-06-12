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
        switch (commandExecutor)
        {
            case var ce when commandExecutor as CommandExecutorBase<IProduceUnitCommand>:
                if (ce != null)
                {
                    ce.ExecuteCommand(_context.Inject(new ProduceUnitCommandHeir()));
                }
                break;
            case var ce when commandExecutor as CommandExecutorBase<IAttackCommand>:
                if (ce != null)
                {
                    ce.ExecuteCommand(new AttackCommand());
                }
                break;
            case var ce when commandExecutor as CommandExecutorBase<IMoveCommand>:
                if (ce != null)
                {
                    ce.ExecuteCommand(new MoveCommand());
                }
                break;
            case var ce when commandExecutor as CommandExecutorBase<IPatrolCommand>:
                if (ce != null)
                {
                    ce.ExecuteCommand(new PatrolCommand());
                }
                break;
            case var ce when commandExecutor as CommandExecutorBase<IStopCommand>:
                if (ce != null)
                {
                    ce.ExecuteCommand(new StopCommand());
                }
                break;
            default:
                throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClick)}:" +
                    $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }
    }
}
