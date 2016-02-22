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
        Dictionary<Hex, List<Hex>> graph = new Dictionary<Hex, List<Hex>>();
        _pool.CreateEntity()
            .AddGraph(graph);

        foreach(Entity e in _group.GetEntities())
        {
            List<Hex> neighborsPosition = new List<Hex>();

            foreach(Entity node in _group.GetEntities())
            {
                foreach(Hex position in e.tilePosition.position.GetNeighborsPositions())
                {
                    if(Hex.IsEqual(node.tilePosition.position, position))
                    {
                        neighborsPosition.Add(position);
                    }
                }
            }

            _pool.graph.graph.Add(e.tilePosition.position, neighborsPosition);

            foreach(Hex position in _pool.graph.graph[e.tilePosition.position])
            {
                Debug.Log(e.tilePosition.position.ToString() + " : " + position.ToString());
            }
            
        }
    }
}
