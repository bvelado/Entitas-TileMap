namespace Entitas {
    public partial class Entity {
        public GraphComponent graph { get { return (GraphComponent)GetComponent(ComponentIds.Graph); } }

        public bool hasGraph { get { return HasComponent(ComponentIds.Graph); } }

        public Entity AddGraph(System.Collections.Generic.Dictionary<Hex, System.Collections.Generic.List<Hex>> newGraph) {
            var componentPool = GetComponentPool(ComponentIds.Graph);
            var component = (GraphComponent)(componentPool.Count > 0 ? componentPool.Pop() : new GraphComponent());
            component.graph = newGraph;
            return AddComponent(ComponentIds.Graph, component);
        }

        public Entity ReplaceGraph(System.Collections.Generic.Dictionary<Hex, System.Collections.Generic.List<Hex>> newGraph) {
            var componentPool = GetComponentPool(ComponentIds.Graph);
            var component = (GraphComponent)(componentPool.Count > 0 ? componentPool.Pop() : new GraphComponent());
            component.graph = newGraph;
            ReplaceComponent(ComponentIds.Graph, component);
            return this;
        }

        public Entity RemoveGraph() {
            return RemoveComponent(ComponentIds.Graph);;
        }
    }

    public partial class Pool {
        public Entity graphEntity { get { return GetGroup(Matcher.Graph).GetSingleEntity(); } }

        public GraphComponent graph { get { return graphEntity.graph; } }

        public bool hasGraph { get { return graphEntity != null; } }

        public Entity SetGraph(System.Collections.Generic.Dictionary<Hex, System.Collections.Generic.List<Hex>> newGraph) {
            if (hasGraph) {
                throw new EntitasException("Could not set graph!\n" + this + " already has an entity with GraphComponent!",
                    "You should check if the pool already has a graphEntity before setting it or use pool.ReplaceGraph().");
            }
            var entity = CreateEntity();
            entity.AddGraph(newGraph);
            return entity;
        }

        public Entity ReplaceGraph(System.Collections.Generic.Dictionary<Hex, System.Collections.Generic.List<Hex>> newGraph) {
            var entity = graphEntity;
            if (entity == null) {
                entity = SetGraph(newGraph);
            } else {
                entity.ReplaceGraph(newGraph);
            }

            return entity;
        }

        public void RemoveGraph() {
            DestroyEntity(graphEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherGraph;

        public static IMatcher Graph {
            get {
                if (_matcherGraph == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Graph);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherGraph = matcher;
                }

                return _matcherGraph;
            }
        }
    }
}
