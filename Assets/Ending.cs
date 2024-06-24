using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enumerator());
    }

    private IEnumerator Enumerator()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("CutScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
