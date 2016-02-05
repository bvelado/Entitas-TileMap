public static class ComponentIds {
    public const int Graph = 0;
    public const int Node = 1;
    public const int Tile = 2;
    public const int TilePosition = 3;
    public const int TileType = 4;
    public const int TileView = 5;

    public const int TotalComponents = 6;

    public static readonly string[] componentNames = {
        "Graph",
        "Node",
        "Tile",
        "TilePosition",
        "TileType",
        "TileView"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(GraphComponent),
        typeof(NodeComponent),
        typeof(TileComponent),
        typeof(TilePositionComponent),
        typeof(TileTypeComponent),
        typeof(TileViewComponent)
    };
}