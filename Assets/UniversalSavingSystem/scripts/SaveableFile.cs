using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class SaveableFile
{
    public readonly List<Data> datas = new List<Data>();

    public SaveableFile(GatherableData[] data)
    {
        data.ToList().ForEach(x =>
        {
            datas.Add(x.data);
        });
    }
}
