using System.Threading;
using UnityEngine;

public class UnitStop : CommandExecutorBase<IStopCommand>
{
    public CancellationTokenSource cancellationTokenSource { get; set; }

    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        cancellationTokenSource?.Cancel();
    }
}
