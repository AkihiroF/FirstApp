using System;
using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.gameObject);
    }

    public void ShootStart(float live)
    {
        StartCoroutine(StartMoving(live));
    }

    IEnumerator StartMoving(float live)
    {
        yield return new WaitForSeconds(live);
        Destroy(transform.gameObject);
    }
}
