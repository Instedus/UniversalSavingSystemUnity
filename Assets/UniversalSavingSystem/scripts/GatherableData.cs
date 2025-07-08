using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GatherableData : MonoBehaviour
{
    Vector _pos;
    Vector _rot;
    Vector _scale;

    [SerializeField] string _prefabPath = string.Empty;

    public string objectName;

    bool isRespawnable;

    public Data data;

    public void MakeIsRespawnable()
    {
        isRespawnable = true;
    }

    private void Awake()
    {
        GeneratePrefabPath();
    }

    public void GatherData()
    {
        _pos = Vector.GenerateNewVector(transform.position.x, transform.position.y, transform.position.z);

        _rot = Vector.GenerateNewVector(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        _scale = Vector.GenerateNewVector(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        objectName = this.gameObject.name;

        data = new Data(_pos,_rot,_scale,_prefabPath,objectName,isRespawnable);
    }

    void GeneratePrefabPath()
    {
        if (!_prefabPath.Equals(string.Empty)) return;

        string[] parts = this.name.Split(new string[] { "(Clone)" }, System.StringSplitOptions.None);

        _prefabPath = parts[0];
    }
}
