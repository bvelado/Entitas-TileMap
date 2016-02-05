public static class ComponentIds {
    public const int Completed = 0;
    public const int Graph = 1;
    public const int Input = 2;
    public const int Node = 3;
    public const int Path = 4;
    public const int Request = 5;
    public const int Tile = 6;
    public const int TilePosition = 7;
    public const int TileSelected = 8;
    public const int TileType = 9;
    public const int TileView = 10;

    public const int TotalComponents = 11;

    public static readonly string[] componentNames = {
        "Completed",
        "Graph",
        "Input",
        "Node",
        "Path",
        "Request",
        "Tile",
        "TilePosition",
        "TileSelected",
        "TileType",
        "TileView"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(CompletedComponent),
        typeof(GraphComponent),
        typeof(InputComponent),
        typeof(NodeComponent),
        typeof(PathComponent),
        typeof(RequestComponent),
        typeof(TileComponent),
        typeof(TilePositionComponent),
        typeof(TileSelectedComponent),
        typeof(TileTypeComponent),
        typeof(TileViewComponent)
    };
}