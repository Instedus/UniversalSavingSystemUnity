using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PrefabCollector : MonoBehaviour
{
    //public static List<string> paths = new List<string>();

    //public static List<GameObject> prefabs = new List<GameObject>();

    //[InitializeOnLoadMethod]
    //private static void OnProjectLoaded()
    //{
    //    EditorApplication.playModeStateChanged += OnPlayModeChanged;
    //}

    //private static void OnPlayModeChanged(PlayModeStateChange state)
    //{
    //    if (state == PlayModeStateChange.EnteredPlayMode)
    //    {
    //        CollectPrefabsFromResources();
    //    }
    //}

    //private static void CollectPrefabsFromResources()
    //{
    //    prefabs.Clear();
    //    paths.Clear();

    //    string resourcesPath = "Assets/Resources";

    //    string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab", new[] { resourcesPath });

    //    foreach (string guid in prefabGUIDs)
    //    {
    //        string fullPath = AssetDatabase.GUIDToAssetPath(guid);
    //        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(fullPath);

    //        if (prefab != null)
    //        {
    //            prefabs.Add(prefab);
    //            paths.Add(fullPath.Replace(resourcesPath + "/", "").Replace(".prefab", ""));
    //        }

    //        Debug.Log($"Collected {prefabs.Count} prefabs from path: {resourcesPath}");
    //    }
    //}
}
