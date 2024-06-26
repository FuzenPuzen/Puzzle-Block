using System.Collections.Generic;
using UnityEngine;
using Zenject;
using EventBus;


public class FieldCheckService : IService
{
    [Inject] private IServiceFabric _serviceFabric;
    [Inject] private ShapeSpawnService _shapeSpawnService;
    [Inject] private FieldViewService _fieldViewService;
    [Inject] private IScoreDataManager _scoreDataManager;
    private EventBinding<OnShapePlaced> _shapePlaced;

    private DropZoneView[,] _fieldPoints;
    private List<ShapeViewService> _shapeViewServices;
    private List<Vector2> _shapePoints;


    public void ActivateService()
    {
        _fieldPoints = _fieldViewService.GetFiledPoints();
        _shapeViewServices = _shapeSpawnService.GetShapeViewServices();
        _shapePlaced = new(CheckField);
    }

    public void DeactivateService()
    {
        _shapePlaced.Remove(CheckField);
    }

    public void CheckField()
    {
        CheckFullLines();
        CheckFreePlace();
    }

    public void CheckFreePlace()
    {
        bool freeSpace = false;
        _shapeViewServices = _shapeSpawnService.GetShapeViewServices();

        foreach (var shape in _shapeViewServices)
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (CheckShapePlace(shape, i, j))
                    {
                        freeSpace = true;
                        return;
                    }
                }
            }

        if (!freeSpace) EventBus<OnLoose>.Raise();
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

    public void CheckFullLines()
    {
        int[] rowSum = new int[10];
        int[] columnSum = new int[10];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                rowSum[i] += _fieldPoints[i, j].IsFree() ? 0 : 1;
                columnSum[j] += _fieldPoints[i, j].IsFree() ? 0 : 1;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (rowSum[i] == 10)
            {
                _scoreDataManager.AddLineScore();
                ClearRow(i);
            }
        }

        for (int j = 0; j < 10; j++)
        {
            if (columnSum[j] == 10)
            {
                _scoreDataManager.AddLineScore();
                ClearColumn(j);
            }
        }
    }

    public void ClearRow(int i)
    {
        _fieldViewService.ClearRow(i);
    }

    public void ClearColumn(int j)
    {
        _fieldViewService.ClearColumn(j);
    }
}
