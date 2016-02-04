using Entitas;

public class NodeComponent : IComponent {
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
