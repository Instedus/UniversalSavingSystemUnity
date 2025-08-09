using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class SaveableFile
{
    public readonly List<Data> datas = new List<Data>();

    public readonly string sceneName;
    public SaveableFile(GatherableData[] data, string sceneName)
    {
        data.ToList().ForEach(x =>
        {
            datas.Add(x.data);
        });

        this.sceneName = sceneName;
    }
}
