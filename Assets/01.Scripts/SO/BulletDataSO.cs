using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/Bullet")]

public class BulletDataSO : ScriptableObject
{
    [Header("�Ѿ� ����")]
    public int RifleBulletCnt;
    public int ShotBulletCnt;
    public int RocketBulletCnt;

    [Header("�Ѿ� �ӵ�")]
    public float RifleBulletSpeed;
    public float ShotBulletSpeed;
    public float RocketBulletSpeed;

    [Header("�߻� �ӵ�")]
    public float RifleShootSpeed;
    public float ShotShootSpeed;
    public float RocketShootSpeed;

    [Header("ź����")]
    public float RifleSpread;
    public float ShotSpread;
    public float RocketSpread;

    [Header("������")]
    public float RifleDamage;
    public float ShotDamage;
    public float RocketDamage;
}
