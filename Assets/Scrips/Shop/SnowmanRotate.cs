using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanRotate : MonoBehaviour
{
    [SerializeField] int snowmanRotateSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, snowmanRotateSpeed * Time.deltaTime, 0);
    }
}
