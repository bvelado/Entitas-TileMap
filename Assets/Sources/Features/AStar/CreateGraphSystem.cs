using UnityEngine;
using System.Collections.Generic;
using Entitas;
using System;

public class CreateGraphSystem : IInitializeSystem, ISetPool
{
    Pool _pool;
    Group _group;

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _group = _pool.GetGroup(Matcher.AllOf(Matcher.Tile, Matcher.TilePosition));
    }

    public void Initialize()
    {
        _pool.CreateEntity().AddGraph(new Dictionary<Entity, Entity[]>());

        foreach(Entity e in _group.GetEntities() )
        {
            List<Entity> tempNeighbors = new List<Entity>();
            _pool.graph.graph.Add(e, null);

            // Look for neighbours using TilePosition
            foreach(Entity tile in _group.GetEntities())
            {
                // West
                if(tile.tilePosition.x == e.tilePosition.x-1 && tile.tilePosition.y == e.tilePosition.y)
                {
                    tempNeighbors.Add(tile);
                }
                
                // East
                if(tile.tilePosition.x == e.tilePosition.x+1 && tile.tilePosition.y == e.tilePosition.y)
                {
                    tempNeighbors.Add(tile);
                }

                // For odd rows (impair)
                if(e.tilePosition.y %2 > 0)
                {
                    // North West
                    if(tile.tilePosition.x == e.tilePosition.x && tile.tilePosition.y == e.tilePosition.y + 1)
                    {
                        tempNeighbors.Add(tile);
                    }

                    // North East
                    if (tile.tilePosition.x == e.tilePosition.x + 1 && tile.tilePosition.y == e.tilePosition.y + 1)
                    {
                        tempNeighbors.Add(tile);
                    }

                    // South West
                    if (tile.tilePosition.x == e.tilePosition.x && tile.tilePosition.y == e.tilePosition.y - 1)
                    {
                        tempNeighbors.Add(tile);
                    }

                    // South East
                    if (tile.tilePosition.x == e.tilePosition.x + 1 && tile.tilePosition.y == e.tilePosition.y - 1)
                    {
                        tempNeighbors.Add(tile);
                    }

                    // For even rows (pair)
                } else {
                    // North West
                    if (tile.tilePosition.x == e.tilePosition.x - 1 && tile.tilePosition.y == e.tilePosition.y + 1)
                    {
                        tempNeighbors.Add(tile);
                    }

                    // North East
                    if (tile.tilePosition.x == e.tilePosition.x && tile.tilePosition.y == e.tilePosition.y + 1)
                    {
                        tempNeighbors.Add(tile);
                    }

                    // South West
                    if (tile.tilePosition.x == e.tilePosition.x - 1 && tile.tilePosition.y == e.tilePosition.y - 1)
                    {
                        tempNeighbors.Add(tile);
                    }

                    // South East
                    if (tile.tilePosition.x == e.tilePosition.x && tile.tilePosition.y == e.tilePosition.y - 1)
                    {
                        tempNeighbors.Add(tile);
                    }
                }

                Entity[] neighboursArray = new Entity[tempNeighbors.Count];
                for(int i = 0; i < tempNeighbors.Count; i++)
                {
                    neighboursArray[i] = tempNeighbors[i];
                }

                _pool.graph.graph[e] = neighboursArray;
            }
        }

        foreach(Entity e in _group.GetEntities())
        {
            if(e.tilePosition.x == -5 && e.tilePosition.y == 4)
            {
                foreach(Entity neighbor in _pool.graph.graph[e])
                {
                    Debug.Log("[" + neighbor.tilePosition.x + ";" + neighbor.tilePosition.y + "]");
                }
            }
        }
    }
}
