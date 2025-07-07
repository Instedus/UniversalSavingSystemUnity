using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class BinarySaving : ISaveable
{
	public void Save(string path, object obj){
		try
		{
			using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate)){	
				BinaryFormatter formatter = new BinaryFormatter();
				
				formatter.Serialize(stream, obj);

				Debug.Log(path);

				Debug.Log("saved succesfuly");
			}
		}
		catch
		{
			Debug.LogError("error on saving");
		}
	}
	
	public T Load<T>(string path){
		try{
			using(FileStream stream = new FileStream(path, FileMode.Open)){
				BinaryFormatter formatter = new BinaryFormatter();
				
				var toReturn = (T)formatter.Deserialize(stream);
				
				Debug.Log("load successfuly");
				
				return toReturn;
				
			}
		}
		catch{
			Debug.LogError("error on loading");		
		}
		
		throw new UnityException();
	}
	
	public void Dispose(){
		GC.SuppressFinalize(this);
	}
}
