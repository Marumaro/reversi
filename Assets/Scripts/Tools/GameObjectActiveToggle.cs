using UnityEditor;
using UnityEngine;

/// <summary>
/// HierarchyにGameObjectのアクティブを切り替えるToggleを表示する拡張
/// </summary>
public class GameObjectActiveToggle
{
    private const int ToggleWidth = 16;

    [InitializeOnLoadMethod]
    private static void Initialize()
    {
        EditorApplication.hierarchyWindowItemOnGUI += ShowToggle;
    }
    
    private static void ShowToggle(int instanceId, Rect rect)
    {
        var obj = EditorUtility.InstanceIDToObject(instanceId) as GameObject;

        if (obj == null) { return; }

        var pos = rect;
        pos.x = pos.xMax - ToggleWidth;
        pos.width = ToggleWidth;

        var isActive = GUI.Toggle(pos, obj.activeSelf, string.Empty);
        obj.SetActive(isActive);
    }
}
