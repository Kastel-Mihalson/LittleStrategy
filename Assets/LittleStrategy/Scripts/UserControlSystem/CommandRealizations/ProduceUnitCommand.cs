using UnityEngine;
using Zenject;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [InjectAsset("UnitViking")]
    private GameObject _unitPrefab;
    public GameObject UnitPrefab => _unitPrefab;

    [Inject(Id = "UnitViking")] public string UnitName { get; }
    [Inject(Id = "UnitViking")] public Sprite Icon { get; }
    [Inject(Id = "UnitViking")] public float ProductionTime { get; }
}
