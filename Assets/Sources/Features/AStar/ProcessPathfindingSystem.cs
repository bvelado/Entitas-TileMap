using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

public class ProcessPathfindingSystem : IReactiveSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Path, Matcher.Request).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities) {
            foreach(var tile in _pool.GetEntities(Matcher.Tile))
            {
                tile.AddNode(null, 0, 0, 0);
            }

            bool pathComplete = false;

            Entity startNode = e.request.start;
            Entity targetNode = e.request.target;

            List<Entity> openList = new List<Entity>();
            List<Entity> closedList = new List<Entity>();

            openList.Add(startNode);

            Entity currentNode = startNode;

            while (openList.Count > 0 && !pathComplete)
            {
                currentNode = openList[0];
                foreach(Entity node in openList)
                {
                    if(node.node.fcost < currentNode.node.fcost || (node.node.fcost == currentNode.node.fcost && node.node.hcost < currentNode.node.hcost))
                    {
                        currentNode = node;
                    }
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (currentNode == targetNode)
                {
                    e.IsCompleted(true);
                    e.path.path = PoolExtensions.RetracePath(startNode, targetNode);
                    pathComplete = true;
                } else
                {
                    foreach(Entity neighbor in _pool.graph.graph[currentNode])
                    {
                        if(!closedList.Contains(neighbor))
                        {
                            if(!openList.Contains(neighbor) || neighbor.node.fcost > currentNode.node.fcost)
                            {
                                float newGcostToNeighbor = currentNode.node.gcost + PoolExtensions.GetDistanceBetweenNodes(currentNode, neighbor);
                                if(newGcostToNeighbor < neighbor.node.gcost || !openList.Contains(neighbor))
                                {
                                    neighbor.node.gcost = newGcostToNeighbor;
                                    neighbor.node.hcost = PoolExtensions.GetDistanceBetweenNodes(neighbor, targetNode);
                                    neighbor.node.fcost = neighbor.node.gcost + neighbor.node.hcost;
                                    neighbor.node.parent = currentNode;

                                    if(!openList.Contains(neighbor))
                                    {
                                        openList.Add(neighbor);
                                    }
                                }
                            }
                        } 
                    }
                }
            }
        }
    }
}
