using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : PoolableMono, IDamageable
{
    [SerializeField]
    private LayerMask _whatIsGround;

    [SerializeField]
    private int _maxHP;
    private int _currentHP;

    [SerializeField]
    private float _timeSlow;
    [SerializeField]
    private float _timeSlowTime;
    [SerializeField]
    private float _shakeScreen;

    public bool IsDead;

    public UnityEvent OnDeadTriggered;
    public UnityEvent OnInitEvent;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    public void OnDamage(int damage)
    {
        if (IsDead) return;
        _currentHP -= damage;
        StartCoroutine(TimeSlow());
        CameraManager.Instance.CamShake(_shakeScreen);

        Debug.Log(_currentHP);
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
        if (_currentHP <= 0)
        {
            IsDead = true;
            OnDeadTriggered?.Invoke();
            GameManager.Instance.killCnt++;
        }
    }

    private IEnumerator TimeSlow()
    {
        Time.timeScale = _timeSlow;
        yield return new WaitForSeconds(_timeSlowTime);
        Time.timeScale = 1f;
    }

    public void ClearEnemy()
    {
        StartCoroutine(Clear());
    }

    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(2f);
        PoolManager.Instance.Push(this);
    }

    public override void Init()
    {
        IsDead = false;
        OnInitEvent?.Invoke();
    }
}
