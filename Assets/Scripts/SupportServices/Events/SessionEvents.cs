using EventBus;

public struct OnShapePlaced : IEvent { public ShapeViewService shapeViewService; }
public struct OnLineCheck : IEvent { public ShapeViewService shapeViewService; }
public struct ScoreChanged : IEvent { public int score; }
public struct OnLoose : IEvent { }
public struct OnRestart : IEvent { }