using EventBus;
using Zenject;

public class GameState : IBaseState
{
    [Inject] private StateMachine _stateMachine;
    private EventBinding<OnLoose> _onLoose;

    public void Enter()
    {
        _onLoose = new(OnLoose);
    }

    public void Exit()
    {
        _onLoose.Remove(OnLoose);
    }

    public void OnLoose()
    {
        _stateMachine.SetState<LooseState>();
    }

}
