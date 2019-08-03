using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class SceneBuildIndexCreator
{
    /// <summary> 無効な文字 </summary>
    private static readonly string[] InvalidChars =
    {
        " ", "!", "\"", "#", "$",
        "%", "&", "\'", "(", ")",
        "-", "=", "^",  "~", "\\",
        "|", "[", "{",  "@", "`",
        "]", "}", ":",  "*", ";",
        "+", "/", "?",  ".", ">",
        ",", "<"
    };

    private const string ItemName = "Tools/SceneBuildIndex 作成";
    private const string FilePath = "Assets/SceneBuildIndex.cs";
    private const string ClassName = "SceneBuildIndex";

    /// <summary>
    /// スクリプト作成
    /// </summary>
    [MenuItem(ItemName)]
    public static void CreateScript()
    {
        if (!IsPossibleCreate()) { return; }

        var scriptCode = new StringBuilder();

        scriptCode.AppendLine("/// <summary>");
        scriptCode.AppendLine("/// シーンのビルドインデックスを定数で管理するクラス");
        scriptCode.AppendLine("/// </summary>");
        scriptCode.AppendLine($"public class {ClassName}");
        scriptCode.AppendLine("{");

        var sceneDataList = EditorBuildSettings.scenes.Select((value, index) => new { name = RemoveInvalidChars(Path.GetFileNameWithoutExtension(value.path)), buildIndex = index });

        foreach (var sceneData in sceneDataList)
        {
            scriptCode.Append("\t").AppendFormat($"public const int {sceneData.name} = {sceneData.buildIndex};").AppendLine();
        }

        scriptCode.AppendLine("}");

        var directoryName = Path.GetDirectoryName(FilePath);
        if (directoryName == null) { return; }

        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        File.WriteAllText(FilePath, scriptCode.ToString(), Encoding.UTF8);
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);

        EditorUtility.DisplayDialog("SceneBuildIndexGenerator", $"{ClassName}.cs の作成が完了致しました", "OK");
    }

    /// <summary>
    /// 作成可能か
    /// </summary>
    /// <returns>可能か</returns>
    public static bool IsPossibleCreate()
    {
        return !EditorApplication.isPlaying && !Application.isPlaying && !EditorApplication.isCompiling;
    }

    /// <summary>
    /// 無効な文字を削除して返す
    /// </summary>
    /// <param name="str">文字</param>
    /// <returns>更新された文字</returns>
    public static string RemoveInvalidChars(string str)
    {
        Array.ForEach(InvalidChars, c => str = str.Replace(c, string.Empty));
        return str;
    }
}
