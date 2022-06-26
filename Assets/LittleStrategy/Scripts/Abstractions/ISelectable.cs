using UnityEngine;

public interface ISelectable : IHealthHolder, IIconHolder
{
    string Name { get; }
    Transform PivotPoint { get; }

    void SetSelected();
    void UnsetSelected();
}
