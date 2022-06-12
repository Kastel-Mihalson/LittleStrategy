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

    private ISelectable _activeSelectabeObject;

    public void Update()
    {
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }

        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }
        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));

        if (hits.Length == 0)
        {
            return;
        }

        if (_activeSelectabeObject != null)
        {
            _activeSelectabeObject.UnsetSelected();
        }

        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault();

        _selectObject.SetValue(selectable);
        _activeSelectabeObject = selectable;

        if (selectable != null)
        {
            selectable.SetSelected();
        }
    }
}
