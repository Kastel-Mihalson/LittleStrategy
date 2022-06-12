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
    private Transform _groundTransform;

    private Plane _groundPlane;

    private ISelectable _activeSelectabeObject;

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

        if (Input.GetMouseButtonUp(0))
        {
            var hits = Physics.RaycastAll(ray);

            if (hits.Length == 0)
            {
                return;
            }

            if (_activeSelectabeObject != null)
            {
                _activeSelectabeObject.UnsetSelected();
            }

            var selectable = hits
                .Select(hit => hit.collider
                    .GetComponentInParent<ISelectable>())
                .Where(c => c != null)
                .FirstOrDefault();

            _selectObject.SetValue(selectable);
            _activeSelectabeObject = selectable;

            if (selectable != null)
            {
                selectable.SetSelected();
            }
        }
        else
        {
            if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        }
    }
}
