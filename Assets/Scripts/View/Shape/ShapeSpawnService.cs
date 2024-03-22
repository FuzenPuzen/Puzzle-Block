using System.Collections.Generic;
using UnityEngine;
using Zenject;
using EventBus;

public interface IShapeSpawnService : IService
{

}

public class ShapeSpawnService : IShapeSpawnService
{
	[Inject] private IServiceFabric _serviceFabric;
	[Inject] private ISOStorageService _sOStorageService;
	private ShapesData _shapesData;
    private ShapeViewService _shapeViewService;
    private List<ShapeViewService> _shapeViewServices = new();

    private EventBinding<ShapePlaced> _shapePlaced;

    public void ActivateService()
	{
        _shapePlaced = new(ShapeCounter);
        LoadShapeList();
        SpawnShapes();
    }

    private void SpawnShapes()
	{
        _shapeViewServices?.Clear();
        for (int i = 0; i < 3; i++)
        {
            int randomId = Random.Range(0, _shapesData.ShapeDictionary.Count);
            _shapeViewService = _serviceFabric.InitMultiple<ShapeViewService>();
            _shapeViewServices.Add(_shapeViewService);
            _shapeViewService.SetShape(_shapesData.ShapeDictionary[randomId]);
            _shapeViewService.ActivateService();
        }
    }

    private void LoadShapeList()
	{
        _shapesData = (ShapesData)_sOStorageService.GetSOByType<ShapesData>();
    }

    public List<ShapeViewService> GetShapeViewServices() => _shapeViewServices;

    private void ShapeCounter(ShapePlaced shapePlaced)
    {
        _shapeViewServices.Remove(shapePlaced.shapeViewService);
        if (_shapeViewServices.Count == 0)
        {
            SpawnShapes();
        }
    }
		
}
