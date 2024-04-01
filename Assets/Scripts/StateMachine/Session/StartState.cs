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


    public void Enter()
    {
        _fieldViewService.ActivateService();
        _shapeSpawnPlaceService.ActivateService();
        _shapeSpawnService.ActivateService();
        _fieldCheckService.ActivateService();
        _scorePanelViewService.ActivateService();
        _loosePanelViewService.ActivateService();
        _stateMachine.SetState<GameState>();
    }

    public void Exit()
    {
       
    }
}
