using Zenject;

public interface IShapeSpawnService : IService
{

}

public class ShapeSpawnService : IShapeSpawnService
{
	private IServiceFabric _serviceFabric;
	private ShapeViewService _shapeViewService;

    [Inject]
	public void Constructor(IServiceFabric fabric)
	{
        _serviceFabric = fabric;
    }
	
	public void ActivateService()
	{
		for (int i = 0; i < 3; i++)
		{
			_shapeViewService = _serviceFabric.InitMultiple<ShapeViewService>();
			_shapeViewService.ActivateService();
        }
	}
}
