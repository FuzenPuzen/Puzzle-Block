using System.Collections.Generic;
using UnityEngine;
using Zenject;
using EventBus;
using Unity.VisualScripting.FullSerializer;

public interface IFieldCheckService : IService
{

}

public class FieldCheckService : IFieldCheckService
{
	[Inject] private IServiceFabric _serviceFabric;
	[Inject] private ShapeSpawnService _shapeSpawnService;
	[Inject] private FieldViewService _fieldViewService;
    private EventBinding<ShapePlaced> _shapePlaced;

    private DropZoneView[,] _fieldPoints;
	private List<ShapeViewService> _shapeViewServices;
	private List<Vector2> _shapePoints;


    public void ActivateService()
	{
        _fieldPoints = _fieldViewService.GetFiledPoints();
        _shapeViewServices = _shapeSpawnService.GetShapeViewServices();
		_shapePlaced = new(CheckFreePlace);
    }

	private void CheckFreePlace()
	{
        _shapeViewServices = _shapeSpawnService.GetShapeViewServices();
        foreach (var shape in _shapeViewServices)
			for (int i = 0; i < 10; i++)
			{
                for (int j = 0; j < 10; j++)
                    if (CheckShapePlace(shape, i, j))
                        MonoBehaviour.print(i +" "+ j + " True");
			}
    }

	public bool CheckShapePlace(ShapeViewService shapeViewService, int i, int j)
	{
		if (!_fieldPoints[i, j].IsFree())
            return false;
        _shapePoints = shapeViewService.ShapeData.points;
		foreach (var point in _shapePoints)
		{
			if (i + point.x < 0 || j + point.y < 0)
                return false;
            if (i + point.x >= 10 || j + point.y >= 10)
                return false;
            if (!_fieldPoints[i + (int)point.x, j + (int)point.y].IsFree())
                return false;
        }
		return true;

    }
}
