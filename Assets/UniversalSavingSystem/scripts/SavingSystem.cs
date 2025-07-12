using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingSystem : MonoBehaviour
{
	public event Action OnSave;

	public event Action OnLoad;

	List<List<GatherableData>> datas = new List<List<GatherableData>>();

	List<string> sceneNames = new List<string>();

	public static SavingSystem Instance;
	
	void Awake(){
		DontDestroyOnLoad(this.gameObject);
		Instance = this;
	}
	
	void FindDatas(){

        GatherableData[] newdatas = GameObject.FindObjectsOfType<GatherableData>();

		newdatas.ToList().ForEach(x =>
		{
			datas[datas.Count-1].Add(x);
		});
	}

	void GatherDataFromObjects()
	{
		datas.ToList().ForEach(x => {
			x.ToList().ForEach(y =>
			{
				y.GatherData();
			});
		});
	}

	void CreateNewSave()
	{
		int index = 0;

		datas.ForEach(data =>
		{
			using (BinarySaving saver = new ())
			{
				SaveableFile file = new (data.ToArray());

				saver.Save(CombineSavePath(sceneNames[index]), file);

                index++;
			}
		});
	}

	string CombineSavePath(string sceneName)
	{
		return Path.Combine(Application.persistentDataPath, sceneName + ".dat");
	}

	public void Save()
	{
		GatherDataFromObjects();

		CreateNewSave();

		OnSave?.Invoke();
	}

	public void TestLoad()
	{
		int index = 0;

		SaveableFile file = null;

        datas.ForEach(data =>
        {
            using (BinarySaving saver = new())
            {
				file = saver.Load<SaveableFile>(CombineSavePath(sceneNames[index]));

                index++;
            }
        });

		file.datas.ForEach(x =>
		{
			Debug.Log(x._prefabPath);
			Debug.Log(x.objectName);

			Debug.Log(x._pos.x);
			Debug.Log(x._pos.y);
			Debug.Log(x._pos.z);
		});

		OnLoad?.Invoke();
    }

	public void Load()
	{
		int index = sceneNames.Where(x => 
			x.Equals(SceneManager.GetActiveScene().name))
			.ConvertTo<int>();

		SaveableFile save = null;

		using (BinarySaving saver = new BinarySaving())
		{
			save = saver.Load<SaveableFile>(CombineSavePath(sceneNames[index]));
		}
	}

	public void AddScene()
	{
		sceneNames.Add(SceneManager.GetActiveScene().name);

		datas.Add(new List<GatherableData>());

		FindDatas();
	}
}
