using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreTable : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;
    private void Awake()
    {
        entryContainer = transform.Find("EntryContainer");
        entryTemplate = entryContainer.Find("EntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string stringHighScore = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(stringHighScore);
        if (highScores != null)
        {
            highScoreEntryList = highScores.highScoreEntryList;
        }
        else
        {
            highScoreEntryList = new List<HighScoreEntry>();
        }

        // sort highScoreList
        for (int i = 0; i < highScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highScoreEntryList.Count; j++)
            {
                if (highScoreEntryList[j].score > highScoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highScoreEntryList[i];
                    highScoreEntryList[i] = highScoreEntryList[j];
                    highScoreEntryList[j] = tmp;
                }
            }
        }
        int index = 0;
        highScoreEntryTransformList = new List<Transform>();
        if (highScoreEntryList.Count > 0)
        {
            foreach (HighScoreEntry highScoreEntry in highScoreEntryList)
            {
                if (index < 10)
                {
                    CreateHighscoreEntry(highScoreEntry, entryContainer, highScoreEntryTransformList);
                    index++;
                }
            }
        }
        else
        {
            CreateEmptyHighScoreEntry(entryContainer);
        }
    }

    private void CreateHighscoreEntry(HighScoreEntry highScoreEntry, Transform container, List<Transform> entryList)
    {
        float templateHeight = 30f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * entryList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = entryList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("PosCol").GetComponent<Text>().text = rankString;

        int score = highScoreEntry.score;
        entryTransform.Find("ScoreCol").GetComponent<Text>().text = score.ToString();

        entryList.Add(entryTransform);
    }

    private void CreateEmptyHighScoreEntry(Transform container)
    {
        float templateHeight = 30f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight);
        entryTransform.gameObject.SetActive(true);

        entryTransform.Find("PosCol").GetComponent<Text>().text = "---";
        entryTransform.Find("ScoreCol").GetComponent<Text>().text = "---";
    }
}

public class HighScores
{
    public List<HighScoreEntry> highScoreEntryList;
}

[System.Serializable]
public class HighScoreEntry
{
    public int score;
}