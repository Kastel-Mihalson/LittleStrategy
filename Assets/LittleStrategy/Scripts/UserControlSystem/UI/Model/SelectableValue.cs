using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), 
    menuName = "ScriptableObject/StrategyGame/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : StatefulScriptableObjectValueBase<ISelectable>
{
}
