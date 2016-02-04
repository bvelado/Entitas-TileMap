namespace Entitas {
    public partial class Entity {
        public TileTypeComponent tileType { get { return (TileTypeComponent)GetComponent(ComponentIds.TileType); } }

        public bool hasTileType { get { return HasComponent(ComponentIds.TileType); } }

        public Entity AddTileType(TileType newType) {
            var componentPool = GetComponentPool(ComponentIds.TileType);
            var component = (TileTypeComponent)(componentPool.Count > 0 ? componentPool.Pop() : new TileTypeComponent());
            component.type = newType;
            return AddComponent(ComponentIds.TileType, component);
        }

        public Entity ReplaceTileType(TileType newType) {
            var componentPool = GetComponentPool(ComponentIds.TileType);
            var component = (TileTypeComponent)(componentPool.Count > 0 ? componentPool.Pop() : new TileTypeComponent());
            component.type = newType;
            ReplaceComponent(ComponentIds.TileType, component);
            return this;
        }

        public Entity RemoveTileType() {
            return RemoveComponent(ComponentIds.TileType);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTileType;

        public static IMatcher TileType {
            get {
                if (_matcherTileType == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TileType);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTileType = matcher;
                }

                return _matcherTileType;
            }
        }
    }
}
