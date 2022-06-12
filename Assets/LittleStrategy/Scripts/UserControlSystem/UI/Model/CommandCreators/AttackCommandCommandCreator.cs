using System;

public class AttackCommandCommandCreator : CommandCreatorBase<IAttackCommand>
{
    protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    {
    }
}
