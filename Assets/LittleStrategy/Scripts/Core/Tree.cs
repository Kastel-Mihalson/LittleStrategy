using UnityEngine;

public class Tree : MonoBehaviour, ISelectable
{
    [SerializeField]
    private GameObject _unitPrefab;
    [SerializeField]
    private Transform _unitsParent;
    [SerializeField]
    private float _maxHealth = 50;
    [SerializeField]
    private Sprite _icon;

    private string _name = "Tree";
    private float _health = 50;

    public string Name => _name;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
}
