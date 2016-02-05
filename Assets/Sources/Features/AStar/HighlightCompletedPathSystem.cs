using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class HighlightCompletedPathSystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Path, Matcher.Completed).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {   
            foreach(var node in e.path.path)
            {
                if (node.hasTileView)
                {
                    node.tileView.model.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }
    }

    
}
