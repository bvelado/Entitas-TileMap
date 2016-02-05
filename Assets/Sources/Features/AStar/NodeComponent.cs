using Entitas;

public class NodeComponent : IComponent {
    /// <summary>
    /// The node from where we can access this node
    /// </summary>
    public Entity parent;

    /// <summary>
    /// Coût total d'une node
    /// </summary>
    public float fcost;

    /// <summary>
    /// Coût pour se déplacer jusqu'à la node depuis la case de départ
    /// </summary>
    public float gcost;

    /// <summary>
    /// Coût pour se déplacer jusqu'a la node finale depuis celle-ci
    /// </summary>
    public float hcost;
}
