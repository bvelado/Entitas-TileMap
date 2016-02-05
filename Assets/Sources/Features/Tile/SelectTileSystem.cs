using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SelectTileSystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Tile, Matcher.TileSelected).OnEntityAddedOrRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            if(e.hasTileView && e.isTileSelected)
            {
                e.tileView.model.GetComponent<SpriteRenderer>().color = Color.yellow;
            } else if (e.hasTileView && !e.isTileSelected)
            {
                e.tileView.model.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
