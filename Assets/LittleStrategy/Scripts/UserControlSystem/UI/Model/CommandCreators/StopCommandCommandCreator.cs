using System;

public class StopCommandCommandCreator : CommandCreatorBase<IStopCommand>
{
    protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
    {
    }
}

