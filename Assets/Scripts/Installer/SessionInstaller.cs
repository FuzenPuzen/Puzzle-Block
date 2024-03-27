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
        Container.Bind<ScorePanelViewService>().AsSingle();
        Container.Bind<LoosePanelViewService>().AsSingle();
        Container.Bind<IScoreDataManager>().To<ScoreDataManager>().AsSingle();

    }
}
