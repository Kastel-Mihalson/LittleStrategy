using UnityEngine;

public sealed class ProduceUnitCommand : IProduceUnitCommand
{
    [InjectAsset("UnitViking")]
    private GameObject _unitPrefab;
    public GameObject UnitPrefab => _unitPrefab;
}
