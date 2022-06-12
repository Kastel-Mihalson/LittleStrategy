using UnityEngine;

public interface ISelectable : IHealthHolder
{
    string Name { get; }
    float Health { get; }
    float MaxHealth { get; }
    Transform PivotPoint { get; }
    Sprite Icon { get; }

    void SetSelected();
    void UnsetSelected();
}
