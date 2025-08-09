using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetsLoader
{
    public static async Task<GameObject> Load(string assetsId)
    {
        var handle = Addressables.InstantiateAsync(assetsId);

        GameObject go = await handle.Task;

        return go;
    }

    public static void UnLoad(GameObject obj)
    {
        if (!obj)
        {
            return;
        }

        obj.SetActive(false);

        Addressables.ReleaseInstance(obj);

        obj = null;
    }
}
