using UnityEditor;
using UnityEngine;

public static class CompileController
{
    private static bool _isLock = false;

    [MenuItem("Editor/Compile/Lock")]
    public static void LockCompile()
    {
        if (_isLock) { return; }

        EditorApplication.LockReloadAssemblies();
        _isLock = true;

        Debug.Log("CompileLock");
    }

    [MenuItem("Editor/Compile/Unlock")]
    public static void UnlockCompile()
    {
        if (!_isLock) { return; }

        EditorApplication.UnlockReloadAssemblies();
        _isLock = false;

        Debug.LogFormat("CompileUnLock : Compiling = {0}", EditorApplication.isCompiling);
    }
}
