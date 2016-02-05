using Entitas;
using Entitas.CodeGenerator;
using System.Collections.Generic;

[SingleEntity]
public class GraphComponent : IComponent {
    public Dictionary<Entity, Entity[]> graph;
}
