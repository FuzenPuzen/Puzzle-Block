using Zenject;

public class InitState : IBaseState
{
    [Inject] private IMarkerService _markerService;
    [Inject] private StateMachine _stateMachine;
    [Inject] private GameCanvasViewService _gameCanvasViewService;
    [Inject] private MainCameraViewService _mainCameraViewService;



    public void Enter()
    {
        _mainCameraViewService.ActivateService();
        _markerService.ActivateService();
        _gameCanvasViewService.ActivateService();
        _stateMachine.SetState<StartState>();
    }

    public void Exit()
    {
        
    }

}
