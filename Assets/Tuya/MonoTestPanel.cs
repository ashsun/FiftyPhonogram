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

	private Card _card;

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
		
		_card = new Card(Card, _testList[_currentIndex].Phonogram, 2);
		_card.HideCard(_testList[_currentIndex].TestType);
	}

	public void OnClickCard()
	{
		_card.ShowCard(false);
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
