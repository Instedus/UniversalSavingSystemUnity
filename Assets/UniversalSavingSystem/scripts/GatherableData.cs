using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GatherableData : MonoBehaviour
{
    Vector _pos;
    Vector _rot;
    Vector _scale;

    string _prefabPath;

    public string objectName;

    bool isRespawnable;

    public Data data;

    public void MakeIsRespawnable()
    {
        isRespawnable = true;
    }

    public void GatherData()
    {
        _pos = Vector.GenerateNewVector(transform.position.x, transform.position.y, transform.position.z);

        _rot = Vector.GenerateNewVector(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        _scale = Vector.GenerateNewVector(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        if (isRespawnable) _prefabPath = AssetDatabase.GetAssetPath(PrefabUtility.GetCorrespondingObjectFromOriginalSource(this.gameObject));

        objectName = this.gameObject.name;

        data = new Data(_pos,_rot,_scale,_prefabPath,objectName,isRespawnable);
    }
}
