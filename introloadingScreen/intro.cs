using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(disablefade());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator disablefade()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("mainMenu");

    }
}
