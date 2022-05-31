using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonsView : MonoBehaviour
{
    public Action<ICommandExecutor> onClick;

    [SerializeField]
    private GameObject _attackButton;
    [SerializeField]
    private GameObject _moveButton;
    [SerializeField]
    private GameObject _patrolButton;
    [SerializeField]
    private GameObject _stopButton;
    [SerializeField]
    private GameObject _produceButton;

    private Dictionary<Type, GameObject> _buttonsByExecutorType;

    void Start()
    {
        _buttonsByExecutorType = new Dictionary<Type, GameObject>();
        _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
        _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
        _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
        _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IStopCommand>), _stopButton);
        _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IProduceUnitCommand>), _produceButton);
    }

    public void MakeLayout(List<ICommandExecutor> commandExecutors)
    {
        foreach (var commandExecutor in commandExecutors)
        {
            var buttonGameObject = _buttonsByExecutorType
                .Where(t => t.Key.IsAssignableFrom(commandExecutor.GetType()))
                .First().Value;

            buttonGameObject.SetActive(true);
            
            var button = buttonGameObject.GetComponent<Button>();

            button.onClick.AddListener(() => onClick?.Invoke(commandExecutor));
        }
    }

    public void Clear()
    {
        foreach (var item in _buttonsByExecutorType)
        {
            item.Value.GetComponent<Button>().onClick.RemoveAllListeners();
            item.Value.SetActive(false);
        }
    }
}
