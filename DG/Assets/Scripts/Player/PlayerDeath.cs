using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _scoreTextAmount;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private GameObject _inGameScore;

    public void ShowScore(int score)
    {
        _scoreText.text = "Score";
        _scoreTextAmount.text = score.ToString();
    }

    public void ShowNewScore(int score)
    {
        _scoreText.text = "New Score";
        _scoreTextAmount.text = score.ToString();
    }

    public void ShowDeathScreen()
    {
        _deathScreen.SetActive(true);
        _inGameScore.SetActive(false);
        Time.timeScale = 0;
    }
}
