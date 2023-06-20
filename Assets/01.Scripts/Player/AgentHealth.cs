using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHP;
    public float _currentHP;

    public UnityEvent OnDeadTrigger = null;

    public bool IsDead;

    private void Start()
    {
        _currentHP = _maxHP;
        UIManager.Instance.HealthUI(_currentHP, _maxHP);
    }

    public void OnDamage(int damage)
    {
        if (IsDead) return;

        _currentHP -= damage;
        UIManager.Instance.HealthUI(_currentHP, _maxHP);
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
        if (_currentHP <= 0)
        {
            DeadProcess();
        }

        OnDeadTrigger?.Invoke();
        Debug.Log(_currentHP);
    }

    private void DeadProcess()
    {
        IsDead = true;
    }
}
