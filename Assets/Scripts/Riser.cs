using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riser : MonoBehaviour
{
    private float originHeight;
    private float noiseValue;
    private void Start()
    {
        //Cube生成随机初始高度
        originHeight = Random.Range(0, 0.4f);
        transform.position = new Vector3(transform.position.x, originHeight, transform.position.z);

        //噪声图生成无规则波动
        noiseValue = Mathf.PerlinNoise(transform.position.x, transform.position.y);
    }
    private void Update()
    {
        transform.localScale = new Vector3(1, Mathf.Sin(Time.time * 10 * noiseValue) * 0.3f + 2, 1);
    }
}
