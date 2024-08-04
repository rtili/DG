using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private PlayerScore _pS;
    [SerializeField] private PlayerDeath _pD;

    public void UpdateScore()
    {
        _pD.ShowDeathScreen();
        if (_pS.Score > _pS.MaxScore)
        {
            _pS.MaxScore = _pS.Score;
            _pS.SaveMaxScore();
            _pD.ShowNewScore(_pS.Score);
        }
        else
        {
            _pD.ShowScore(_pS.Score);
        }
    }
}
