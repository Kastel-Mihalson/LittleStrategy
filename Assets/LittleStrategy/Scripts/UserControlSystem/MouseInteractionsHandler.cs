using System.Linq;
using UnityEngine;

public class MouseInteractionsHandler : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private SelectableValue _selectObject;

    public void Update()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }
        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));

        if (hits.Length == 0)
        {
            return;
        }

        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault();

        _selectObject.SetValue(selectable);

        if (selectable is IUnitProducer)
        {
            var mainBuilding = (IUnitProducer)selectable;
            mainBuilding.ProduceUnit();
        }
    }
}
