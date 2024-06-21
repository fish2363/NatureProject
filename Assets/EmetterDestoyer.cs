using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmetterDestoyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(0.65f);
        gameObject.SetActive(false);
    }
}
