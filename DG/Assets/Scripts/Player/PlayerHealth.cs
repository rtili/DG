using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDeath, IInvulnerable
{
    public bool IsInvulnerable { get { return _isInvulnerable; } set { _isInvulnerable = value; } }
    [SerializeField] private UnityEvent Death;
    private bool _isInvulnerable = false;

    public void Dead()
    {
        Death.Invoke();
    }
}
