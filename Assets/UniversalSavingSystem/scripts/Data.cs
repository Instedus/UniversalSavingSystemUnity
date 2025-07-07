using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Data
{
    public readonly Vector _pos;
    public readonly Vector _rot;
    public readonly Vector _scale;

    public readonly string _prefabPath;

    public readonly string objectName;

    public readonly bool isRespawnable;

    public Data(Vector _pos, Vector _rot, Vector _scale, string _prefabPath, string objectName, bool isRespawnable)
    {
        this._pos = _pos;
        this._rot = _rot;
        this._scale = _scale;
        this._prefabPath = _prefabPath;
        this.objectName = objectName;
        this.isRespawnable = isRespawnable;
    }
}
