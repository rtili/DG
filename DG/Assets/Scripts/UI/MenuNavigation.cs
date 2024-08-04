using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] private Text _maxScoreText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            _maxScoreText.text = PlayerPrefs.GetInt("MaxScore").ToString();
        }
        else
        {
            _maxScoreText.text = "0";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
