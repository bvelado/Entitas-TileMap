using Entitas;
using System.Collections.Generic;
using UnityEngine;

public static class PoolExtensions {

    public static float GetDistanceBetweenNodes(Entity a, Entity b)
    {
        float dstX = Mathf.Abs(a.tilePosition.x - b.tilePosition.x);
        float dstY = Mathf.Abs(a.tilePosition.y - b.tilePosition.y);

        return dstX + dstY;
    }

    public static List<Entity> RetracePath(Entity startNode, Entity endNode)
    {
        List<Entity> path = new List<Entity>();
        Entity currentNode = endNode;
        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.node.parent;
        }

        path.Reverse();

        return path;
    }
}
