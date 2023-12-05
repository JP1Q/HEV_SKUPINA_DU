using UnityEngine;
using UnityEditor;

public class LightingGenerator : MonoBehaviour
{
    [ContextMenu("Generate Lighting")]
    void GenerateLighting()
    {
#if UNITY_EDITOR
        // > zbiju te pokud tohle neudelas > unity tohle udela vzdycky
        UnityEditor.AssetDatabase.Refresh();

        // Zafixovat svetlo protoze unity ma alzheimer
        UnityEditor.Lightmapping.Bake();

        Debug.Log("Lighting generated successfully.");
#endif
    }
}
