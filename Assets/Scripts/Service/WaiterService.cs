using Zenject;

public interface IWaiterService : IService
{

}

public class WaiterService : IWaiterService
{
	[Inject] private IServiceFabric _serviceFabric;
	
	public void ActivateService()
	{       
        
	}
}
