namespace Entitas {
    public partial class Entity {
        public NodeComponent node { get { return (NodeComponent)GetComponent(ComponentIds.Node); } }

        public bool hasNode { get { return HasComponent(ComponentIds.Node); } }

        public Entity AddNode(float newFcost, float newGcost, float newHcost) {
            var componentPool = GetComponentPool(ComponentIds.Node);
            var component = (NodeComponent)(componentPool.Count > 0 ? componentPool.Pop() : new NodeComponent());
            component.fcost = newFcost;
            component.gcost = newGcost;
            component.hcost = newHcost;
            return AddComponent(ComponentIds.Node, component);
        }

        public Entity ReplaceNode(float newFcost, float newGcost, float newHcost) {
            var componentPool = GetComponentPool(ComponentIds.Node);
            var component = (NodeComponent)(componentPool.Count > 0 ? componentPool.Pop() : new NodeComponent());
            component.fcost = newFcost;
            component.gcost = newGcost;
            component.hcost = newHcost;
            ReplaceComponent(ComponentIds.Node, component);
            return this;
        }

        public Entity RemoveNode() {
            return RemoveComponent(ComponentIds.Node);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherNode;

        public static IMatcher Node {
            get {
                if (_matcherNode == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Node);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherNode = matcher;
                }

                return _matcherNode;
            }
        }
    }
}
