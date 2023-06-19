using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/Bullet")]

public class BulletDataSO : ScriptableObject
{
    [Header("ÃÑ¾Ë °³¼ö")]
    public int RifleBulletCnt;
    public int ShotBulletCnt;
    public int RocketBulletCnt;

    [Header("ÃÑ¾Ë ¼Óµµ")]
    public float RifleBulletSpeed;
    public float ShotBulletSpeed;
    public float RocketBulletSpeed;

    [Header("¹ß»ç ¼Óµµ")]
    public float RifleShootSpeed;
    public float ShotShootSpeed;
    public float RocketShootSpeed;

    [Header("ÅºÆÛÁü")]
    public float RifleSpread;
    public float ShotSpread;
    public float RocketSpread;

    [Header("µ¥¹ÌÁö")]
    public float RifleDamage;
    public float ShotDamage;
    public float RocketDamage;
}
