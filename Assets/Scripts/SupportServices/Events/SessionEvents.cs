using EventBus;

public struct OnShapePlaced : IEvent { public ShapeViewService shapeViewService; }
public struct OnLineCheck : IEvent { public ShapeViewService shapeViewService; }
public struct ScoreChanged : IEvent { public int score; }
public struct RecordChanged : IEvent { public int record; }
public struct OnLoose : IEvent { }
public struct OnRestart : IEvent { }
public struct OnRestartButton : IEvent { }