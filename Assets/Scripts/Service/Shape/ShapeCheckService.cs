using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IShapeCheckService : IService
{
    public bool CheckFieldSpace(ShapeData shapeData);
}

public class ShapeCheckService : IShapeCheckService
{
    [Inject] private FieldViewService _fieldViewService;

    private DropZoneView[,] _fieldPoints;
    private List<Vector2> _shapePoints;

    public void ActivateService()
	{
        _fieldPoints = _fieldViewService.GetFiledPoints();
    }

	public bool CheckFieldSpace(ShapeData shapeData)
	{
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {               
                if (CheckShapePlace(shapeData, i, j))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckShapePlace(ShapeData shapeData, int i, int j)
    {
        if (!_fieldPoints[i, j].IsFree())
            return false;
        _shapePoints = shapeData.points;

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
