using Zenject;

public class StartState : IBaseState
{
    [Inject] private ShapeSpawnPlaceViewService _shapeSpawnPlaceService;
    [Inject] private ShapeSpawnService _shapeSpawnService;
    [Inject] private FieldViewService _fieldViewService;
    [Inject] private FieldCheckService _fieldCheckService;

    public void Enter()
    {
        _fieldViewService.ActivateService();
        _shapeSpawnPlaceService.ActivateService();
        _shapeSpawnService.ActivateService();
        _fieldCheckService.ActivateService();
    }

    public void Exit()
    {
        
    }

}
