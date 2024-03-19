using Zenject;

public class SessionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<StateMachine>().AsSingle();
        Container.Bind<GameCanvasViewService>().AsSingle();
        Container.Bind<ShapeSpawnViewService>().AsSingle();
    }
}
