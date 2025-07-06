using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Data : MonoBehaviour
{
    Vector _pos;
    Vector _rot;
    Vector _scale;

    string _prefabPath;

    public string objectName;

    bool isRespawnable;

    public void MakeIsRespawnable()
    {
        isRespawnable = true;
    }

    public void GatherData()
    {
        _pos = GenerateNewVector(transform.position.x, transform.position.y, transform.position.z);

        _rot = GenerateNewVector(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        
        _scale = GenerateNewVector(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        if(isRespawnable) _prefabPath = AssetDatabase.GetAssetPath(PrefabUtility.GetCorrespondingObjectFromOriginalSource(this.gameObject));
    
        objectName = this.gameObject.name;
    }

    Vector GenerateNewVector(float x, float y, float z)
    {
        return new Vector(x, y, z);
    }
}
