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
    /// Coût pour se déplacer jusqu'à la node
    /// </summary>
    public float gcost;
    /// <summary>
    /// Coût heuristique. Approximation de combien celà 
    /// va coûter de se déplacer jusqu'a la node finale
    /// </summary>
    public float hcost;
}
