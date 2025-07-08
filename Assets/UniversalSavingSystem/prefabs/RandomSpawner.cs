using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject box;

    private void Awake()
    {
        for (int i = 0; i < Random.Range(0,100); i++)
        {
            GameObject newBox = Instantiate(box, new Vector3(Random.Range(-100,100), Random.Range(-100, 100), Random.Range(-100, 100)), Quaternion.identity);

            newBox.GetComponent<GatherableData>().MakeIsRespawnable();
        }
    }


    bool isFlag;
    float timer;
    private void Update()
    {
        timer += Time.deltaTime;

        if (!isFlag && timer > 3f)
        {
            SavingSystem.Instance.AddScene();
            SavingSystem.Instance.Save();
            SavingSystem.Instance.Load();

            isFlag = true;
        }
    }

}
