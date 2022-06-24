using UnityEngine;
using Zenject;

public class UiModelInstaller : MonoInstaller
{
    [SerializeField]
    private Sprite _unitSprite;

    public override void InstallBindings()
    {
        Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
            .To<ProduceUnitCommandCommandCreator>().AsTransient();

        Container.Bind<CommandCreatorBase<IAttackCommand>>()
            .To<AttackCommandCommandCreator>().AsTransient();

        Container.Bind<CommandCreatorBase<IMoveCommand>>()
            .To<MoveCommandCommandCreator>().AsTransient();

        Container.Bind<CommandCreatorBase<IPatrolCommand>>()
            .To<PatrolCommandCommandCreator>().AsTransient();

        Container.Bind<CommandCreatorBase<IStopCommand>>()
            .To<StopCommandCommandCreator>().AsTransient();

        Container.Bind<CommandButtonsModel>().AsTransient();

        Container.Bind<float>().WithId("UnitViking").FromInstance(5f);
        Container.Bind<string>().WithId("UnitViking").FromInstance("UnitViking");
        Container.Bind<Sprite>().WithId("UnitViking").FromInstance(_unitSprite);

        Container.Bind<BottomCenterModel>().AsSingle();
    }
}
