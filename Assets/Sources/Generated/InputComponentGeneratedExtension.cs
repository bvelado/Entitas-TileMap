namespace Entitas {
    public partial class Entity {
        public InputComponent input { get { return (InputComponent)GetComponent(ComponentIds.Input); } }

        public bool hasInput { get { return HasComponent(ComponentIds.Input); } }

        public Entity AddInput(InputIntent newIntent, object[] newData) {
            var componentPool = GetComponentPool(ComponentIds.Input);
            var component = (InputComponent)(componentPool.Count > 0 ? componentPool.Pop() : new InputComponent());
            component.intent = newIntent;
            component.data = newData;
            return AddComponent(ComponentIds.Input, component);
        }

        public Entity ReplaceInput(InputIntent newIntent, object[] newData) {
            var componentPool = GetComponentPool(ComponentIds.Input);
            var component = (InputComponent)(componentPool.Count > 0 ? componentPool.Pop() : new InputComponent());
            component.intent = newIntent;
            component.data = newData;
            ReplaceComponent(ComponentIds.Input, component);
            return this;
        }

        public Entity RemoveInput() {
            return RemoveComponent(ComponentIds.Input);;
        }
    }

    public partial class Pool {
        public Entity inputEntity { get { return GetGroup(Matcher.Input).GetSingleEntity(); } }

        public InputComponent input { get { return inputEntity.input; } }

        public bool hasInput { get { return inputEntity != null; } }

        public Entity SetInput(InputIntent newIntent, object[] newData) {
            if (hasInput) {
                throw new EntitasException("Could not set input!\n" + this + " already has an entity with InputComponent!",
                    "You should check if the pool already has a inputEntity before setting it or use pool.ReplaceInput().");
            }
            var entity = CreateEntity();
            entity.AddInput(newIntent, newData);
            return entity;
        }

        public Entity ReplaceInput(InputIntent newIntent, object[] newData) {
            var entity = inputEntity;
            if (entity == null) {
                entity = SetInput(newIntent, newData);
            } else {
                entity.ReplaceInput(newIntent, newData);
            }

            return entity;
        }

        public void RemoveInput() {
            DestroyEntity(inputEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherInput;

        public static IMatcher Input {
            get {
                if (_matcherInput == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Input);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherInput = matcher;
                }

                return _matcherInput;
            }
        }
    }
}
