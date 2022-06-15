using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] 
    private UnitMovementStop _stop;

    [SerializeField] 
    private Animator _animator;

    [SerializeField] 
    private UnitStop _stopCommandExecutor;

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        GetComponent<NavMeshAgent>().destination = command.Target;

        _animator.SetTrigger(Animator.StringToHash(nameof(AnimationTypes.Walk)));
        _stopCommandExecutor.cancellationTokenSource = new CancellationTokenSource();

        try
        {
            await _stop.WithCancellation(
                _stopCommandExecutor.cancellationTokenSource.Token);
        }
        catch
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().ResetPath();
        }
        _stopCommandExecutor.cancellationTokenSource = null;
        _animator.SetTrigger(Animator.StringToHash(nameof(AnimationTypes.Idle)));
    }
}
