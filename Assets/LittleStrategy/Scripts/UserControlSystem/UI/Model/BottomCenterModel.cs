using System;
using UniRx;
using UnityEngine;
using Zenject;

public class BottomCenterModel : MonoBehaviour
{
    public IObservable<IUnitProducer> UnitProducers { get; private set; }

    [Inject]
    public void Init(IObservable<ISelectable> currentlySelected)
    {
        UnitProducers = currentlySelected
        .Select(selectable => selectable as Component)
        .Select(component => component?.GetComponent<IUnitProducer>());
    }
}
