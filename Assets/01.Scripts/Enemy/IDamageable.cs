using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void OnDamage(int damage, Vector3 point, Vector3 normal);
}
