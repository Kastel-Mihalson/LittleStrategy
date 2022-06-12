using UnityEngine;

public class Unit : MonoBehaviour, ISelectable, IAttackable
{
    [SerializeField]
    private GameObject _unitPrefab;

    [SerializeField]
    private Transform _unitsParent;

    [SerializeField]
    private Transform _unitTransform;

    [SerializeField]
    private float _maxHealth = 150;

    [SerializeField]
    private Sprite _icon;

    [SerializeField]
    private GameObject _selected;

    private string _name = "Unit Viking";
    private float _health = 150;

    public string Name => _name;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    public Transform PivotPoint => _unitTransform;

    public void UnsetSelected()
    {
        _selected.SetActive(false);
    }

    public void SetSelected()
    {
        _selected.SetActive(true);
    }
}
