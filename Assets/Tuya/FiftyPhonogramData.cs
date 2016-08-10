using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class BasePhonogram
{
	public string Hiragana;
	public string Katakana;
	public string Rome;
}

public class FiftyPhonogramData : ScriptableObject
{
	public BasePhonogram[] Phonograms;
}

public class FiftyPhonogramDataLoader
{
	private static FiftyPhonogramData _data;
	public static FiftyPhonogramData GetData()
	{
		if (_data == null)
		{
			_data = GameObject.Instantiate(Resources.Load("Data/FiftyPhonogramData")) as FiftyPhonogramData;
		}

		return _data;
	}
}

public class ChoosedRecord
{
	private static string KEY = "ChoosedRecord";

	public static HashSet<int> LoadChoosedRecord()
	{
		if (!PlayerPrefs.HasKey(KEY))
		{
			return new HashSet<int>();
		}
		else
		{
			string data = PlayerPrefs.GetString(KEY);
			HashSet<int> choosed = new HashSet<int>();
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] == '1')
				{
					choosed.Add(i);
				}
			}
			return choosed;
		}
	}

	public static void SaveChoosedRecord(HashSet<int> choosed)
	{
		string data = "";
		for (int i = 0; i < FiftyPhonogramDataLoader.GetData().Phonograms.Length; i++)
		{
			data += choosed.Contains(i) ? 1 : 0;
		}
		PlayerPrefs.SetString(KEY, data);
	}
}