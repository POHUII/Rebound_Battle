using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletMoveSpeed = 8f;
    public int reboundCount = 4;
    public GameObject boomEffectPrefab;
    public TrailRenderer trail;
    public Light pointLight;

    private Vector3 moveDirection;
    private int currentReboundCount = 0;
    private MeshRenderer meshRenderer;
    private float colorIntensity = 3;
    private AudioSource bulletAudio;

    private void Start()
    {

        trail = GetComponent<TrailRenderer>();
        meshRenderer = GetComponent<MeshRenderer>();
        moveDirection = transform.forward;
        ChangeColor();
        bulletAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime * bulletMoveSpeed, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerMovement playerMovement = collision.transform.GetComponent<PlayerMovement>();
        if (playerMovement)
        {
            Instantiate(boomEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            playerMovement.Dead();
        }
        else
        {
            Vector3 normalVector = collision.GetContact(0).normal;  //法向量
            Vector3 projectVector = Vector3.Project(-moveDirection, normalVector);  //投影向量
            Vector3 theOtherVector = projectVector - (-moveDirection);
            moveDirection = (projectVector + theOtherVector).normalized;  //反射向量

            currentReboundCount++;
            if (currentReboundCount >= reboundCount)
            {
                Instantiate(boomEffectPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                CameraShake._instance.BulletShakeCamera();
            }
            else
            {
                ChangeColor();
                bulletAudio.Play();
            }
        }
    }

    void ChangeColor()
    {
        Color HDRcolor = Tools.GetRandomHDRColor(colorIntensity);
        meshRenderer.material.SetColor("_EmissionColor", HDRcolor);

        trail.material.SetColor("_EmissionColor", HDRcolor);

        pointLight.color = HDRcolor / colorIntensity;
    }
}
