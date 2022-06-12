using UnityEngine;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [InjectAsset("UnitViking")]
    private GameObject _unitPrefab;
    public GameObject UnitPrefab => _unitPrefab;
}
