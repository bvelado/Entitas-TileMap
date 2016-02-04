using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMapSystem : IInitializeSystem, ISetPool {
    Pool _pool;

    int _sizeX, _sizeY;

    readonly GameObject _tileViewContainer = new GameObject("Tiles");

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Initialize()
    {
        _sizeX = Map01.sizeX;
        _sizeY = Map01.sizeY;

        foreach(int[] position in GeneratePositions(_sizeX, _sizeY))
        {
            Entity e = _pool.CreateEntity()
                .IsTile(true)
                .AddTilePosition(position[0], position[1])
                .AddTileType(GenerateTileType());
        }

        GenerateTileView(_pool.GetEntities(Matcher.AllOf(Matcher.Tile, Matcher.TilePosition, Matcher.TileType)));
    }

    List<int[]> GeneratePositions(int sizeX, int sizeY)
    {
        List<int[]> positions = new List<int[]>();

        for(int x = -(sizeX/2); x < (sizeX/2); x++)
        {
            for (int y = -(sizeY / 2); y < (sizeY / 2); y++)
            {
                positions.Add(new int[] { x , y });
            }
        }

        return positions;
    }

    TileType GenerateTileType()
    {
        int[] values = (int[])System.Enum.GetValues(typeof(TileType));

        int randomIndex = Random.Range(0, values.Length);

        return (TileType)values.GetValue(values[randomIndex]);
    }

    void GenerateTileView(Entity[] entities)
    {
        Sprite[] tileSprites = Resources.LoadAll<Sprite>("Sprites/hexagon_tiles");

        foreach (Entity e in entities)
        {
            // Instantiate the game object, name it and put it in a container
            GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/Tile"), new Vector3(e.tilePosition.x, e.tilePosition.y), Quaternion.identity) as GameObject;

            go.name = "Tile [" + e.tilePosition.x + ";" + e.tilePosition.y + "]";
            go.transform.SetParent(_tileViewContainer.transform);
            
            // Assign a view 
            string[] sprites;
            TileTypeResourceCombination.combinations.TryGetValue(e.tileType.type, out sprites);

            string randomSpriteName = sprites[Random.Range(0, sprites.Length)];

            foreach(Sprite sprite in tileSprites)
            {
                if(sprite.name == randomSpriteName)
                {
                    go.GetComponent<SpriteRenderer>().sprite = sprite;
                }
            }

            e.AddTileView(go);
        }
    }
}
