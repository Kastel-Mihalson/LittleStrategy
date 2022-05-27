using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), 
    menuName = "ScriptableObject/StrategyGame/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : ScriptableObject
{
    public ISelectable CurrentValue { get; private set; }
    public Action<ISelectable> OnSelected;

    public void SetValue(ISelectable value)
    {
        CurrentValue = value;
        OnSelected?.Invoke(value);
    }
}
