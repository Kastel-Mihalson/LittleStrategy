using UnityEngine;

public interface ISelectable
{
    string Name { get; }
    float Health { get; }
    float MaxHealth { get; }
    Sprite Icon { get; }

    void SetSelected();
    void UnsetSelected();
}
