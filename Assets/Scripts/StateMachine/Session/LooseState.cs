using EventBus;
using UnityEngine.SceneManagement;
using Zenject;

public class LooseState : IBaseState
{
    [Inject] private StateMachine _stateMachine;
    [Inject] private LoosePanelViewService _loosePanelViewService;
    [Inject] private FieldCheckService _fieldCheckService;
    [Inject] private ShapeSpawnService _shapeSpawnService;
    [Inject] private ScorePanelViewService _scorePanelViewService;
    [Inject] private RecordPanelViewService _recordPanelViewService;
    [Inject] private IRecordDataManager _recordDataManager;
    private EventBinding<OnRestart> _onRestart;

    public void Enter()
    {
        _loosePanelViewService.ShowView();
        _onRestart = new(OnRestartButton);
    }

    public void Exit()
    {
        
    }

    public void OnRestartButton()
    {
        _loosePanelViewService.HideView();
        _onRestart.Remove(OnRestartButton);
        _stateMachine.SetState<RestartState>();
    }
}
