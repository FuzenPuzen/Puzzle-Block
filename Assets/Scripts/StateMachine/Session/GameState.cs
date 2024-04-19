using EventBus;
using System.Diagnostics;
using UnityEngine;
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
        if (_onLoose == null)
        {
            _onLoose = new(OnLoose);
            _onRestart = new(OnRestart);
            _onRestartButton = new(OnRestartButton);
        }
        _onLoose.Add(OnLoose);
        _onRestart.Add(OnRestart);
        _onRestartButton.Add(OnRestartButton);
    }

    public void Exit()
    {
        _onLoose.Remove(OnLoose);
        _onRestart.Remove(OnRestart);
        _onRestartButton.Remove(OnRestartButton);
    }

    public void OnRestart()
    {
        _restartPanelViewService.HideView();
        _stateMachine.SetState<RestartState>();
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
