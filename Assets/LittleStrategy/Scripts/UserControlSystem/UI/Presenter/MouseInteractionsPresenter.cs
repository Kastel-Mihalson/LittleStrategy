using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private SelectableValue _selectObject;

    [SerializeField]
    private EventSystem _eventSystem;

    [SerializeField]
    private Vector3Value _groundClicksRMB;

    [SerializeField] 
    private AttackableValue _attackablesRMB;

    [SerializeField]
    private Transform _groundTransform;

    private Plane _groundPlane;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
    }

    public void Update()
    {
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }

        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);

        if (Input.GetMouseButtonUp(0))
        {
            if (WeHit<ISelectable>(hits, out var selectable))
            {
                _selectObject.SetValue(selectable);
            }
        }
        else
        {
            if (WeHit<IAttackable>(hits, out var attackable))
            {
                _attackablesRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        }
    }

    private bool WeHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;

        if (hits.Length == 0)
        {
            return false;
        }

        result = hits
            .Select(hit => hit.collider
                .GetComponentInParent<T>())
            .Where(c => c != null)
            .FirstOrDefault();

        return result != default;
    }

}
