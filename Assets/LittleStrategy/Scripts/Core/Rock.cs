using UnityEngine;

public class Rock : MonoBehaviour, ISelectable
{
    [SerializeField]
    private GameObject _unitPrefab;
    [SerializeField]
    private Transform _unitsParent;
    [SerializeField]
    private float _maxHealth = 100;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private GameObject _selected;

    private string _name = "Rock";
    private float _health = 100;

    public string Name => _name;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    public void UnsetSelected()
    {
        _selected.SetActive(false);
    }

    public void SetSelected()
    {
        _selected.SetActive(true);
    }
}
