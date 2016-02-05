namespace Entitas {
    public partial class Entity {
        public RequestComponent request { get { return (RequestComponent)GetComponent(ComponentIds.Request); } }

        public bool hasRequest { get { return HasComponent(ComponentIds.Request); } }

        public Entity AddRequest(Entitas.Entity newStart, Entitas.Entity newTarget) {
            var componentPool = GetComponentPool(ComponentIds.Request);
            var component = (RequestComponent)(componentPool.Count > 0 ? componentPool.Pop() : new RequestComponent());
            component.start = newStart;
            component.target = newTarget;
            return AddComponent(ComponentIds.Request, component);
        }

        public Entity ReplaceRequest(Entitas.Entity newStart, Entitas.Entity newTarget) {
            var componentPool = GetComponentPool(ComponentIds.Request);
            var component = (RequestComponent)(componentPool.Count > 0 ? componentPool.Pop() : new RequestComponent());
            component.start = newStart;
            component.target = newTarget;
            ReplaceComponent(ComponentIds.Request, component);
            return this;
        }

        public Entity RemoveRequest() {
            return RemoveComponent(ComponentIds.Request);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherRequest;

        public static IMatcher Request {
            get {
                if (_matcherRequest == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Request);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherRequest = matcher;
                }

                return _matcherRequest;
            }
        }
    }
}
