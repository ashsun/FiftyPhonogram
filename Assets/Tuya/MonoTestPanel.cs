using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public enum TestType
{
	TestHiragana = 0,
	TestKatakana,
	TestRome
}

public class TestCard
{
	public BasePhonogram Phonogram;
	public TestType TestType;
}

public class MonoTestPanel : MonoBehaviour 
{
	public GameObject Index;
	public GameObject Card;
	public GameObject PreviousButton;
	public GameObject NextButton;

	private HashSet<int> _choosed;

	private List<TestCard> _testList;
	private int _currentIndex;

	public void Start() 
	{
		_choosed = ChoosedRecord.LoadChoosedRecord();

		_currentIndex = 0;
		_testList = new List<TestCard>();
		TestCard testCard;
		foreach (int cardID in _choosed)
		{
			foreach (TestType testType in System.Enum.GetValues(typeof(TestType)))
			{
				testCard = new TestCard();
				testCard.Phonogram = FiftyPhonogramDataLoader.GetData().Phonograms[cardID];
				testCard.TestType = testType;

				int randomIndex = Random.Range(0, _testList.Count);
				_testList.Insert(randomIndex, testCard);
			}
		}

		ShowTestCard();
	}

	public void ShowTestCard()
	{
		Index.transform.GetComponent<Text>().text = (_currentIndex + 1) + "/" + _testList.Count;

		Card.transform.Find("Hiragana").GetComponent<Text>().text = _testList[_currentIndex].TestType == TestType.TestHiragana ? _testList[_currentIndex].Phonogram.Hiragana : "";
		Card.transform.Find("Katakana").GetComponent<Text>().text = _testList[_currentIndex].TestType == TestType.TestKatakana ? _testList[_currentIndex].Phonogram.Katakana : "";
		Card.transform.Find("Rome").GetComponent<Text>().text = _testList[_currentIndex].TestType == TestType.TestRome ? _testList[_currentIndex].Phonogram.Rome : "";

		if (_testList[_currentIndex].Phonogram.Hiragana.Length > 1)
		{
			Card.transform.Find("Hiragana").GetComponent<Text>().fontSize = 50;
			Card.transform.Find("Hiragana").transform.localPosition = new Vector3(-44, 18, 0);
		}
		else
		{
			Card.transform.Find("Hiragana").GetComponent<Text>().fontSize = 80;
			Card.transform.Find("Hiragana").transform.localPosition = new Vector3(-44, 0, 0);
		}

		if (_testList[_currentIndex].Phonogram.Katakana.Length > 1)
		{
			Card.transform.Find("Katakana").GetComponent<Text>().fontSize = 50;
			Card.transform.Find("Katakana").transform.localPosition = new Vector3(44, 18, 0);
		}
		else
		{
			Card.transform.Find("Katakana").GetComponent<Text>().fontSize = 80;
			Card.transform.Find("Katakana").transform.localPosition = new Vector3(44, 0, 0);
		}
	}

	public void OnClickCard()
	{
		Card.transform.Find("Hiragana").GetComponent<Text>().text = _testList[_currentIndex].Phonogram.Hiragana;
		Card.transform.Find("Katakana").GetComponent<Text>().text = _testList[_currentIndex].Phonogram.Katakana;
		Card.transform.Find("Rome").GetComponent<Text>().text = _testList[_currentIndex].Phonogram.Rome;
	}

	public void OnClickPreviousButton()
	{
		if (_currentIndex > 0)
		{
			_currentIndex--;

			ShowTestCard();
		}
	}

	public void OnClickNextButton()
	{
		if (_currentIndex < _testList.Count - 1)
		{
			_currentIndex++;

			ShowTestCard();
		}
		else
		{
			SceneManager.LoadScene("Main");
		}
	}
}
