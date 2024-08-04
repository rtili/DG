using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour, ISetScore
{
    public int MaxScore { get { return _maxScore;} set { _maxScore = value; } }
    public int Score { get { return _score; } }
    [SerializeField] private Text _scoreText;
    private int _maxScore;
    private int _score;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            LoadMaxScore();
        }
        else
        {
            _maxScore = 0;
        }
    }

    private void Update()
    {
        _scoreText.text = _score.ToString();
    }

    public void GetScore(int scoreAmount)
    {
        _score += scoreAmount;
    }

    public void SaveMaxScore()
    {
        PlayerPrefs.SetInt("MaxScore", _maxScore);
        PlayerPrefs.Save();
    }

    private void LoadMaxScore()
    {
        _maxScore = PlayerPrefs.GetInt("MaxScore");        
    }
}
