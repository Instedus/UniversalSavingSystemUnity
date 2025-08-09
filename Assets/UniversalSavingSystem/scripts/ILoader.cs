using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface ILoader
{
    public Task<GameObject> Load(string assetsId);

    public void UnLoad(GameObject obj);
}
