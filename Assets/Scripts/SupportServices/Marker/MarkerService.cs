using EventBus;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class  MarkerService : IMarkerService
{
    private List<IMarker> markers = new List<IMarker>();

    private EventBinding<OnMarkerAwake> _onMarkerAwake;
    private int count;
    public void ActivateService()
    {
        _onMarkerAwake = new(SetMarker);
    }

    public void DeActivateService()
    {
        _onMarkerAwake.Remove(SetMarker);
    }

    public T GetTransformMarker<T>() where T : IMarker
    {
        return markers.OfType<T>().FirstOrDefault();
    }

    public void SetMarker(OnMarkerAwake markerAwake)
    {
        markers.Add(markerAwake.marker);
    }
}

public interface IMarkerService: IService
{
    public T GetTransformMarker<T>() where T : IMarker;
    public void DeActivateService();
}

public class Marker: MonoBehaviour, IMarker
{
    public void Awake()
    {
        EventBus<OnMarkerAwake>.Raise(new() {marker = this});
    }
}

public interface IMarker
{
    
}
