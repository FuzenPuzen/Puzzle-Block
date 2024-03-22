using System.Collections.Generic;
using System.Linq;
using Zenject;

public class StateMachine 
{
    private IBaseState _currentState;
    private IServiceFabric _serviceFabric;

    private List<IBaseState> _baseStates = new();

    [Inject]
    public void Constructor(IServiceFabric fabric)
    {
        _serviceFabric = fabric;
    }

    public void SetState<T>() where T : class, IBaseState
    { 
        _currentState?.Exit();
        if (_baseStates.OfType<T>().Any())
        {
            _currentState = _baseStates.OfType<T>().FirstOrDefault();
        }
        else
        {
            _currentState = _serviceFabric.InitSingle<T>();
            _baseStates.Add(_currentState);
        }
        _currentState.Enter();
    }

}
