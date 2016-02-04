namespace Entitas {
    public partial class Entity {
        public TileViewComponent tileView { get { return (TileViewComponent)GetComponent(ComponentIds.TileView); } }

        public bool hasTileView { get { return HasComponent(ComponentIds.TileView); } }

        public Entity AddTileView(UnityEngine.GameObject newModel) {
            var componentPool = GetComponentPool(ComponentIds.TileView);
            var component = (TileViewComponent)(componentPool.Count > 0 ? componentPool.Pop() : new TileViewComponent());
            component.model = newModel;
            return AddComponent(ComponentIds.TileView, component);
        }

        public Entity ReplaceTileView(UnityEngine.GameObject newModel) {
            var componentPool = GetComponentPool(ComponentIds.TileView);
            var component = (TileViewComponent)(componentPool.Count > 0 ? componentPool.Pop() : new TileViewComponent());
            component.model = newModel;
            ReplaceComponent(ComponentIds.TileView, component);
            return this;
        }

        public Entity RemoveTileView() {
            return RemoveComponent(ComponentIds.TileView);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTileView;

        public static IMatcher TileView {
            get {
                if (_matcherTileView == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TileView);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTileView = matcher;
                }

                return _matcherTileView;
            }
        }
    }
}
