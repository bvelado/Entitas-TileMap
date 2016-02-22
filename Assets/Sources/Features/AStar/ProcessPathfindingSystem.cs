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
            bool pathComplete = false;

            Entity startNode = e.request.start;
            Entity targetNode = e.request.target;

            startNode.AddNode(null, PoolExtensions.GetDistanceBetweenNodes(startNode, targetNode), 0, PoolExtensions.GetDistanceBetweenNodes(startNode, targetNode));

            // Nodes to process
            List<Entity> openList = new List<Entity>();
            // Already processed nodes
            List<Entity> closedList = new List<Entity>();

            Entity currentNode;
            openList.Add(startNode);

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
                    
                }
            }
        }
    }
}
