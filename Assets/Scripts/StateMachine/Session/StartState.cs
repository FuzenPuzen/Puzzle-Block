using Zenject;

public class StartState : IBaseState
{
    [Inject] private ShapeSpawnViewService _shapeSpawnService;

    public void Enter()
    {
        _shapeSpawnService.ActivateService();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
