using EventBus;
using Zenject;

public class GameState : IBaseState
{
    [Inject] private StateMachine _stateMachine;
    [Inject] private RestartPanelViewService _restartPanelViewService;
    private EventBinding<OnLoose> _onLoose;
    private EventBinding<OnRestartButton> _onRestartButton;
    private EventBinding<OnRestart> _onRestart;

    public void Enter()
    {
        _onLoose = new(OnLoose);
        _onRestart = new(OnLoose);
        _onRestartButton = new(OnRestartButton);
    }

    public void Exit()
    {
        _onLoose.Remove(OnLoose);
        _onRestart.Remove(OnLoose);
        _onRestartButton.Remove(OnRestartButton);
    }

    public void OnLoose()
    {
        _stateMachine.SetState<LooseState>();
    }

    public void OnRestartButton()
    {
        _restartPanelViewService.ShowView();
    }

}
