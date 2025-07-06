using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableFile
{
    public readonly Data[] datas;

    public SaveableFile(Data[] data)
    {
        this.datas = data;
    }
}
