using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject targetGameObject;
    public float flashInterval = 48f;
    public float flashDuration = 0.1f;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(flashInterval);

            targetGameObject.SetActive(true);
            yield return new WaitForSeconds(flashDuration);
            targetGameObject.SetActive(false);
        }
    }
}



