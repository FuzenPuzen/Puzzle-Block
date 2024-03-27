using EventBus;
using Zenject;

public class StartState : IBaseState
{
    [Inject] private StateMachine _stateMachine;
    [Inject] private ShapeSpawnPlaceViewService _shapeSpawnPlaceService;
    [Inject] private ShapeSpawnService _shapeSpawnService;
    [Inject] private FieldViewService _fieldViewService;
    [Inject] private FieldCheckService _fieldCheckService;
    [Inject] private ScorePanelViewService _scorePanelViewService;
    [Inject] private LoosePanelViewService _loosePanelViewService;
    private EventBinding<OnLoose> _onLoose;

    public void Enter()
    {
        _fieldViewService.ActivateService();
        _shapeSpawnPlaceService.ActivateService();
        _shapeSpawnService.ActivateService();
        _fieldCheckService.ActivateService();
        _scorePanelViewService.ActivateService();
        _loosePanelViewService.ActivateService();
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
