using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHP;
    [SerializeField] private float time;
    [SerializeField] private GameObject obj;
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
        StartCoroutine(TwikleScreen());
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
        if (_currentHP <= 0)
        {
            DeadProcess();
            OnDeadTrigger?.Invoke();
        }

        Debug.Log(_currentHP);
    }

    private IEnumerator TwikleScreen()
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
        yield return new WaitForSeconds(time);
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }

    private void DeadProcess()
    {
        IsDead = true;
    }
}
