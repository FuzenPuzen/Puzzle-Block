using Zenject;

public class SessionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<StateMachine>().AsSingle();
        Container.Bind<GameCanvasViewService>().AsSingle();
        Container.Bind<FieldViewService>().AsSingle();
        Container.Bind<ShapeSpawnPlaceViewService>().AsSingle();
        Container.Bind<ShapeSpawnService>().AsSingle();
        Container.Bind<FieldCheckService>().AsSingle();
    }
}
