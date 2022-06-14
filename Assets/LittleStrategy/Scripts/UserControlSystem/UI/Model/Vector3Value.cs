using UnityEngine;

[CreateAssetMenu(fileName = nameof(Vector3Value), 
    menuName = "ScriptableObject/StrategyGame/" + nameof(Vector3Value), order = 0)]
public class Vector3Value : ScriptableObjectValueBase<Vector3>
{
}
