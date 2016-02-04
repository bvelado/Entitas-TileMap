using System.Collections.Generic;

public enum TileType {
    Grass, Dirt, Sand, RedSand, Concrete
}

public static class TileTypeResourceCombination
{
    public static Dictionary<TileType, string[]> combinations = new Dictionary<TileType, string[]>() {
        { TileType.Grass, new string[] {
            "tile_grass"
        }},
        { TileType.Dirt, new string[] {
            "tile_dirt"
        }},
        { TileType.Sand, new string[] {
            "tile_sand"
        }},
        { TileType.RedSand, new string[] {
            "tile_redSand"
        }},
        { TileType.Concrete, new string[] {
            "tile_concrete"
        }}
    };
}