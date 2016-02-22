using System;
using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEditor;

public class Hex_TypeDrawer : ITypeDrawer {
    public bool HandlesType(Type type) {
        return type == typeof(Hex);
    }

    public object DrawAndGetNewValue(Type type, string fieldName, object value, Entity entity, int index, IComponent component) {
        Hex hex = entity.tilePosition.position;

        hex._q = EditorGUILayout.IntField("q", entity.tilePosition.position._q);
        hex._r = EditorGUILayout.IntField("r", entity.tilePosition.position._r);
        // return your implementation to draw the type Hex
        return hex;
    }
}