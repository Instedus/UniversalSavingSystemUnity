using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingSystem : MonoBehaviour
{
	List<List<Data>> datas = new List<List<Data>>();

	List<string> sceneNames = new List<string>();
	
	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}
	
	void FindDatas(){

		Data[] newdatas = GameObject.FindObjectsOfType<Data>();

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
		return Path.Combine(Application.persistentDataPath, sceneName,".dat");
	}

	public void Save()
	{
		GatherDataFromObjects();
		CreateNewSave();
	}

	public void AddScene()
	{
		sceneNames.Add(SceneManager.GetActiveScene().name);

		FindDatas();
	}
}
