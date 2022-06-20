using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IAttackable
{
    [SerializeField]
    private Transform _unitsParent;

    [SerializeField]
    private Transform _buildTransform;

    [SerializeField]
    private float _maxHealth = 1000;

    [SerializeField]
    private Sprite _icon;

    [SerializeField]
    private GameObject _selected;

    private string _name = "Main Building";
    private float _health = 1000;

    public string Name => _name;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    public Transform PivotPoint => _buildTransform;

    public override async void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        await ProduceUnitAsync(command);
    }

    private async Task ProduceUnitAsync(IProduceUnitCommand command)
    {
        await Task.Delay(2000);

        Instantiate(command.UnitPrefab,
            new Vector3(Random.Range(-10, 10), 0, Random.Range(10, -10)),
            Quaternion.identity, _unitsParent);
    }

    public void UnsetSelected()
    {
        _selected.SetActive(false);
    }

    public void SetSelected()
    {
        _selected.SetActive(true);
    }
}
