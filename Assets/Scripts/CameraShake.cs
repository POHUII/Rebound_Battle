using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public static CameraShake _instance;
    public float bulletDuration = 0.3f;
    public float bulletStrength = 0.2f;
    public float playerDuration = 0.3f;
    public float playerStrength = 0.6f;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayerShakeCamera()
    {
        transform.DOShakePosition(playerDuration, playerStrength);
    }

    public void BulletShakeCamera()
    {
        transform.DOShakePosition(bulletDuration, bulletStrength);
    }
}
