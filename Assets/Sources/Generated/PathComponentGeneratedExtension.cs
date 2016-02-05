namespace Entitas {
    public partial class Entity {
        public PathComponent path { get { return (PathComponent)GetComponent(ComponentIds.Path); } }

        public bool hasPath { get { return HasComponent(ComponentIds.Path); } }

        public Entity AddPath(System.Collections.Generic.List<Entitas.Entity> newPath) {
            var componentPool = GetComponentPool(ComponentIds.Path);
            var component = (PathComponent)(componentPool.Count > 0 ? componentPool.Pop() : new PathComponent());
            component.path = newPath;
            return AddComponent(ComponentIds.Path, component);
        }

        public Entity ReplacePath(System.Collections.Generic.List<Entitas.Entity> newPath) {
            var componentPool = GetComponentPool(ComponentIds.Path);
            var component = (PathComponent)(componentPool.Count > 0 ? componentPool.Pop() : new PathComponent());
            component.path = newPath;
            ReplaceComponent(ComponentIds.Path, component);
            return this;
        }

        public Entity RemovePath() {
            return RemoveComponent(ComponentIds.Path);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherPath;

        public static IMatcher Path {
            get {
                if (_matcherPath == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Path);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherPath = matcher;
                }

                return _matcherPath;
            }
        }
    }
}
