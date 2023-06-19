using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    private Rigidbody _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    public void ShootBullet(Vector3 dir)
    {
        _rigid.AddForce(dir, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PoolManager.Instance.Push(this);
    }

    public override void Init()
    {
        
    }
}
