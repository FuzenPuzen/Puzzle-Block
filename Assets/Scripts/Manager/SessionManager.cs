using UnityEngine;
using Zenject;

public class SessionManager : MonoBehaviour
{
    private ShapeSpawnService _shapeSpawnService;
    private IServiceFabric _serviceFabric;
    private IMarkerService _markerService;
    public GameObject ShapePlace;

    [Inject]
    public void Constructor(IServiceFabric fabric, IMarkerService markerService)
    {
        _markerService = markerService;
        _serviceFabric = fabric;
    }


    void Awake()
    {     
        _markerService.ActivateService();
        ShapePlace.SetActive(true);
        _shapeSpawnService = _serviceFabric.InitSingle<ShapeSpawnService>();
        _shapeSpawnService.ActivateService();
    }


}
