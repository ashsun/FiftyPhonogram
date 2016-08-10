using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Card
{
	private GameObject _card;
	private BasePhonogram _phonogram;
	private float _scale;

	private bool _showOriginal;

	public Card(GameObject card, BasePhonogram phonogram, float scale) 
	{
		_card = card;
		_phonogram = phonogram;
		_scale = scale;

		_showOriginal = false;

		_card.transform.Find("Hiragana").GetComponent<Text>().text = _phonogram.Hiragana;
		_card.transform.Find("HiraganaOriginal").GetComponent<Text>().text = _phonogram.HiraganaOriginal;
		_card.transform.Find("Katakana").GetComponent<Text>().text = _phonogram.Katakana;
		_card.transform.Find("KatakanaOriginal").GetComponent<Text>().text = _phonogram.KatakanaOriginal;
		_card.transform.Find("Rome").GetComponent<Text>().text = _phonogram.Rome;

		card.transform.Find("Hiragana").GetComponent<Text>().fontSize = (int)((_phonogram.Hiragana.Length > 1 ? 25 : 40) * _scale);
		card.transform.Find("Hiragana").transform.localPosition = (_phonogram.Hiragana.Length > 1 ? new Vector3(-22, 9, 0) : new Vector3(-22, 0, 0)) * _scale;
		card.transform.Find("HiraganaOriginal").GetComponent<Text>().fontSize = (int)((_phonogram.HiraganaOriginal.Length > 1 ? 25 : 40) * _scale);
		card.transform.Find("HiraganaOriginal").transform.localPosition = (_phonogram.HiraganaOriginal.Length > 1 ? new Vector3(-22, 9, 0) : new Vector3(-22, 0, 0)) * _scale;
		card.transform.Find("Katakana").GetComponent<Text>().fontSize = (int)((_phonogram.Katakana.Length > 1 ? 25 : 40) * _scale);
		card.transform.Find("Katakana").transform.localPosition = (_phonogram.Katakana.Length > 1 ? new Vector3(22, 9, 0) : new Vector3(22, 0, 0)) * _scale;
		card.transform.Find("KatakanaOriginal").GetComponent<Text>().fontSize = (int)((_phonogram.KatakanaOriginal.Length > 1 ? 25 : 40) * _scale);
		card.transform.Find("KatakanaOriginal").transform.localPosition = (_phonogram.KatakanaOriginal.Length > 1 ? new Vector3(22, 9, 0) : new Vector3(22, 0, 0)) * _scale;

		ShowCard(_showOriginal);
	}

	public void SetChoosed(bool choosed)
	{
		_card.transform.GetComponent<Image>().color = choosed ? Color.yellow : Color.white;
	}

	public void Switch()
	{
		_showOriginal = !_showOriginal;
		ShowCard(_showOriginal);
	}

	public void ShowCard(bool showOriginal)
	{
		_card.transform.Find("Hiragana").gameObject.SetActive(!showOriginal);
		_card.transform.Find("HiraganaOriginal").gameObject.SetActive(showOriginal);
		_card.transform.Find("Katakana").gameObject.SetActive(!showOriginal);
		_card.transform.Find("KatakanaOriginal").gameObject.SetActive(showOriginal);
		_card.transform.Find("Rome").gameObject.SetActive(true);
	}

	public void HideCard(TestType testType)
	{
		_card.transform.Find("Hiragana").gameObject.SetActive(testType == TestType.TestHiragana);
		_card.transform.Find("HiraganaOriginal").gameObject.SetActive(false);
		_card.transform.Find("Katakana").gameObject.SetActive(testType == TestType.TestKatakana);
		_card.transform.Find("KatakanaOriginal").gameObject.SetActive(false);
		_card.transform.Find("Rome").gameObject.SetActive(testType == TestType.TestRome);
	}
}
