using UnityEngine;

[CreateAssetMenu(fileName = nameof(AttackableValue),
    menuName = "ScriptableObject/StrategyGame/" + nameof(AttackableValue), order = 0)]
public class AttackableValue : StatelessScriptableObjectValueBase<IAttackable>
{
}
