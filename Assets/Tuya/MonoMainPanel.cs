using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MonoMainPanel : MonoBehaviour 
{
	public GameObject TestButton;
	public GameObject ChooseAndStartButton;
	public GameObject CardObject;

	private List<Card> _cards;
	private HashSet<int> _choosed;

	public void Start()
	{
		TestButton.SetActive(true);
		ChooseAndStartButton.SetActive(false);

		_cards = new List<Card>();
		_choosed = null;

		GameObject card;
		FiftyPhonogramData data = FiftyPhonogramDataLoader.GetData();
		for (int i = 0; i < data.Phonograms.Length; i++)
		{
			card = GameObject.Instantiate(CardObject) as GameObject;
			card.SetActive(true);
			card.transform.SetParent(transform.Find("Scroll/Viewport/Content"));
			card.name = "Card" + i.ToString("00");

			_cards.Add(new Card(card, data.Phonograms[i], 1));
		}
	}

	public void RefreshChoosed()
	{
		for (int i = 0; i < _cards.Count; i++)
		{
			_cards[i].SetChoosed(_choosed.Contains(i));
		}
	}

	public void OnClickCard(GameObject card)
	{
		FiftyPhonogramData data = FiftyPhonogramDataLoader.GetData();
		int cardID = int.Parse(card.name.Replace("Card", ""));

		if (_choosed != null)
		{
			if (_choosed.Contains(cardID))
			{
				_choosed.Remove(cardID);
			}
			else
			{
				_choosed.Add(cardID);
			}
			ChoosedRecord.SaveChoosedRecord(_choosed);

			RefreshChoosed();
		}
		else
		{
			_cards[cardID].Switch();
		}
	}
	
	public void OnClickTest()
	{
		TestButton.SetActive(false);
		ChooseAndStartButton.SetActive(true);

		for (int i = 0; i < _cards.Count; i++)
		{
			_cards[i].ShowCard(false);
		}

		_choosed = ChoosedRecord.LoadChoosedRecord();

		RefreshChoosed();
	}

	public void OnClickChooseAndStart()
	{
		if (_choosed.Count > 0)
		{
			SceneManager.LoadScene("Test");
		}
	}
}
