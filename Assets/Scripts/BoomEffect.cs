using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    public GameObject effectPrefab;
    public int creatNum = 10;
    public float boomForce = 0.5f;
    public float minScaleFactor = 0.15f;
    public float maxScaleFactor = 0.25f;

    private void Start()
    {
        for (int i = 0; i < creatNum; i++)
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            float scaleFactor = Random.Range(minScaleFactor, maxScaleFactor);
            effect.transform.localScale = Vector3.one * scaleFactor;

            Rigidbody rigid = effect.GetComponent<Rigidbody>();

            if (rigid)
            {
                Vector3 explosionDir = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
                rigid.AddForce(explosionDir.normalized * boomForce, ForceMode.Impulse);
            }
        }
    }
}
