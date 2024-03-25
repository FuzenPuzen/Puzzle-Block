using EventBus;

public struct ShapePlaced : IEvent { public ShapeViewService shapeViewService; }
public struct ScoreChanged : IEvent { public int score; }