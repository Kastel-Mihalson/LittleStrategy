using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
    [SerializeField] 
    private AssetsContext _legacyContext;

    [SerializeField] 
    private Vector3Value _groundClicksRMB;

    [SerializeField] 
    private AttackableValue _attackableClicksRMB;

    [SerializeField] 
    private SelectableValue _selectables;

    [SerializeField]
    private Sprite _unitSprite;

    public override void InstallBindings()
    {
        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_attackableClicksRMB);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_groundClicksRMB);
        Container.Bind<IObservable<ISelectable>>().FromInstance(_selectables);
        Container.Bind<Sprite>().WithId("UnitViking").FromInstance(_unitSprite);
    }
}