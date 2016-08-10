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

	private List<GameObject> _cards;
	private HashSet<int> _choosed;

	public void Start()
	{
		TestButton.SetActive(true);
		ChooseAndStartButton.SetActive(false);

		_cards = new List<GameObject>();
		_choosed = null;

		GameObject card;
		FiftyPhonogramData data = FiftyPhonogramDataLoader.GetData();
		for (int i = 0; i < data.Phonograms.Length; i++)
		{
			card = GameObject.Instantiate(CardObject) as GameObject;
			card.transform.SetParent(transform.Find("Scroll/Viewport/Content"));
			card.transform.Find("Hiragana").GetComponent<Text>().text = data.Phonograms[i].Hiragana;
			card.transform.Find("Katakana").GetComponent<Text>().text = data.Phonograms[i].Katakana;
			card.transform.Find("Rome").GetComponent<Text>().text = data.Phonograms[i].Rome;

			if (data.Phonograms[i].Hiragana.Length > 1)
			{
				card.transform.Find("Hiragana").GetComponent<Text>().fontSize = 25;
				card.transform.Find("Hiragana").transform.localPosition += new Vector3(0, 9, 0);
			}

			if (data.Phonograms[i].Katakana.Length > 1)
			{
				card.transform.Find("Katakana").GetComponent<Text>().fontSize = 25;
				card.transform.Find("Katakana").transform.localPosition += new Vector3(0, 9, 0);
			}

			card.SetActive(true);
			card.name = "Card" + i.ToString("00");

			_cards.Add(card);
		}
	}

	public void RefreshChoosed()
	{
		for (int i = 0; i < _cards.Count; i++)
		{
			_cards[i].transform.GetComponent<Image>().color = _choosed.Contains(i) ? Color.yellow : Color.white;
		}
	}

	public void OnClickCard(GameObject card)
	{
		if (_choosed != null)
		{
			int cardID = int.Parse(card.name.Replace("Card", ""));
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
	}
	
	public void OnClickTest()
	{
		TestButton.SetActive(false);
		ChooseAndStartButton.SetActive(true);

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
