namespace Entitas {
    public partial class Entity {
        static readonly CompletedComponent completedComponent = new CompletedComponent();

        public bool isCompleted {
            get { return HasComponent(ComponentIds.Completed); }
            set {
                if (value != isCompleted) {
                    if (value) {
                        AddComponent(ComponentIds.Completed, completedComponent);
                    } else {
                        RemoveComponent(ComponentIds.Completed);
                    }
                }
            }
        }

        public Entity IsCompleted(bool value) {
            isCompleted = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherCompleted;

        public static IMatcher Completed {
            get {
                if (_matcherCompleted == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Completed);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherCompleted = matcher;
                }

                return _matcherCompleted;
            }
        }
    }
}
