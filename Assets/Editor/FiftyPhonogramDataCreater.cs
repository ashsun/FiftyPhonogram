using UnityEditor;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FiftyPhonogramDataCreater
{
	[MenuItem("Assets/CreateFiftyPhonogramData")]
	public static void CreateFiftyPhonogramData()
	{
		FiftyPhonogramData data = ScriptableObject.CreateInstance<FiftyPhonogramData>();

		string[] hiragana = new string[]
		{ 
			"あ", "い", "う", "え", "お",
			"か", "き", "く", "け", "こ",
			"さ", "し", "す", "せ", "そ",
			"た", "ち", "つ", "て", "と",
			"な", "に", "ぬ", "ね", "の",
			"は", "ひ", "ふ", "へ", "ほ",
			"ま", "み", "む", "め", "も",
			"や", "(い)", "ゆ", "(え)", "よ",
			"ら", "り", "る", "れ", "ろ",
			"わ", "(い)", "(う)", "(え)", "を",
			"ん"
		};
		string[] hiraganaOriginal = new string[]
		{ 
			"安", "以", "宇", "衣", "於",
			"加", "幾", "久", "计", "己",
			"左", "之", "寸", "世", "曽",
			"太", "知", "川", "天", "止",
			"奈", "仁", "奴", "祢", "乃",
			"波", "比", "不", "部", "保",
			"末", "美", "武", "女", "毛",
			"也", "(以)", "由", "(衣)", "与",
			"良", "利", "留", "礼", "吕",
			"和", "(以)", "(宇)", "(衣)", "遠",
			"无"
		};
		string[] katakana = new string[]
		{ 
			"ア", "イ", "ウ", "エ", "オ", 
			"カ", "キ", "ク", "ケ", "コ", 
			"サ", "シ", "ス", "セ", "ソ", 
			"タ", "チ", "ツ", "テ", "ト", 
			"ナ", "ニ", "ヌ", "ネ", "ノ", 
			"ハ", "ヒ", "フ", "へ", "ホ", 
			"マ", "ミ", "ム", "メ", "モ", 
			"ヤ", "(イ)", "ユ", "(エ)", "ヨ", 
			"ラ", "リ", "ル", "レ", "ロ",
			"ワ", "(イ)", "(ウ)", "(エ)", "ヲ", 
			"ン"
		};
		string[] katakanaOriginal = new string[]
		{ 
			"阿", "伊", "宇", "江", "於", 
			"加", "幾", "久", "介", "己", 
			"散", "之", "须", "世", "曽", 
			"多", "千", "川", "天", "止", 
			"奈", "二", "奴", "祢", "乃", 
			"八", "比", "不", "部", "保", 
			"万", "三", "牟", "女", "毛", 
			"也", "(伊)", "由", "(江)", "与", 
			"良", "利", "流", "礼", "吕",
			"和", "(伊)", "(宇)", "(江)", "呼", 
			"尓"
		};
		string[] rome = new string[] 
		{ 
			"a",   "i",   "u",   "e",   "o",
			"ka",  "ki",  "ku",  "ke",  "ko",
			"sa",  "shi", "su",  "se",  "so",
			"ta",  "chi", "tsu", "te",  "to",
			"na",  "ni",  "nu",  "ne",  "no",
			"ha",  "hi",  "fu",  "he",  "ho",
			"ma",  "mi",  "mu",  "me",  "mo",
			"ya",  "(i)", "yu",  "(e)", "yo",
			"ra",  "ri",  "ru",  "re",  "ro",
			"wa",  "(i)", "(u)", "(e)", "o",
			"n"
		};

		data.Phonograms = new BasePhonogram[hiragana.Length];
		for (int i = 0; i < hiragana.Length; i++)
		{
			data.Phonograms[i] = new BasePhonogram();
			data.Phonograms[i].Hiragana = hiragana[i];
			data.Phonograms[i].HiraganaOriginal = hiraganaOriginal[i];
			data.Phonograms[i].Katakana = katakana[i];
			data.Phonograms[i].KatakanaOriginal = katakanaOriginal[i];
			data.Phonograms[i].Rome = rome[i];
		}

		AssetDatabase.CreateAsset(data, "Assets/Resources/Data/FiftyPhonogramData.asset");
		AssetDatabase.SaveAssets();
	}
}
