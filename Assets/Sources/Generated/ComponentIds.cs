public static class ComponentIds {
    public const int Node = 0;
    public const int Tile = 1;
    public const int TilePosition = 2;
    public const int TileType = 3;
    public const int TileView = 4;

    public const int TotalComponents = 5;

    public static readonly string[] componentNames = {
        "Node",
        "Tile",
        "TilePosition",
        "TileType",
        "TileView"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(NodeComponent),
        typeof(TileComponent),
        typeof(TilePositionComponent),
        typeof(TileTypeComponent),
        typeof(TileViewComponent)
    };
}