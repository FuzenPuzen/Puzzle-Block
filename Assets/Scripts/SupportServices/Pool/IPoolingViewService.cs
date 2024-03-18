using System;

public interface IPoolingViewService
{
    public void ActivateServiceFromPool();
    public void SetDeactivateAction(Action<IPoolingViewService> action);
}