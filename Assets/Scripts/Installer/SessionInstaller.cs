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
        Container.Bind<RestartButtonViewService>().AsSingle();
        Container.Bind<MuteButtonViewService>().AsSingle();

        Container.Bind<YSaveService>().AsSingle();
        Container.Bind<YADService>().AsSingle();

        Container.Bind<MainCameraViewService>().AsSingle();
        Container.Bind<TutorialViewService>().AsSingle();
        Container.Bind<RecordPanelViewService>().AsSingle();
        Container.Bind<RestartPanelViewService>().AsSingle();

        Container.Bind<AudioUnitViewService>().AsSingle();
        Container.Bind<IScoreDataManager>().To<ScoreDataManager>().AsSingle();
        Container.Bind<IRecordDataManager>().To<RecordDataManager>().AsSingle();
        Container.Bind<IAudioService>().To<AudioService>().AsSingle();
        Container.Bind<IShapeCheckService>().To<ShapeCheckService>().AsSingle();

    }
}
