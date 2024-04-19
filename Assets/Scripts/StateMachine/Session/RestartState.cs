using System.Diagnostics;
using Zenject;
using UnityEngine;

public class RestartState : IBaseState
{
    [Inject] private StateMachine _stateMachine;
    [Inject] private IScoreDataManager _scoreDataManager;
    [Inject] private IAudioService _audioService;
    [Inject] private ShapeSpawnPlaceViewService _shapeSpawnPlaceViewService;
    [Inject] private ShapeSpawnService _shapeSpawnService;
    [Inject] private FieldViewService _fieldViewService;
    [Inject] private YADService _yADService;

    public void Enter()
    {
        _scoreDataManager.ClearScore();
        _shapeSpawnPlaceViewService.Clear();
        _fieldViewService.ClearField();
        _shapeSpawnService.SpawnShapes();
        _yADService.ShowAD();
        _audioService.PlayAudio(AudioEnum.Line, false);
        _stateMachine.SetState<GameState>();
    }

    public void Exit()
    {
        
    }

}
