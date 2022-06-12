using System;

public class PatrolCommandCommandCreator : CommandCreatorBase<IPatrolCommand>
{
    protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
    {
    }
}

