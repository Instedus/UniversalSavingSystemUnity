using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISaveable : IDisposable
{
	void Save(string path, object obj);
	
	T Load<T>(string path);
}
