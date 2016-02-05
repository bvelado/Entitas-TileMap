namespace Entitas {
    public partial class Entity {
        static readonly TileSelectedComponent tileSelectedComponent = new TileSelectedComponent();

        public bool isTileSelected {
            get { return HasComponent(ComponentIds.TileSelected); }
            set {
                if (value != isTileSelected) {
                    if (value) {
                        AddComponent(ComponentIds.TileSelected, tileSelectedComponent);
                    } else {
                        RemoveComponent(ComponentIds.TileSelected);
                    }
                }
            }
        }

        public Entity IsTileSelected(bool value) {
            isTileSelected = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity tileSelectedEntity { get { return GetGroup(Matcher.TileSelected).GetSingleEntity(); } }

        public bool isTileSelected {
            get { return tileSelectedEntity != null; }
            set {
                var entity = tileSelectedEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isTileSelected = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTileSelected;

        public static IMatcher TileSelected {
            get {
                if (_matcherTileSelected == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TileSelected);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTileSelected = matcher;
                }

                return _matcherTileSelected;
            }
        }
    }
}
