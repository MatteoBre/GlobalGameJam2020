using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class textEnd : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(rabbitSpeech());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator rabbitSpeech()
    {
        text.text = "Amelie was able to restore her path!";
        yield return new WaitForSeconds(5);
        text.text = "But not everything can be repaired...";
        yield return new WaitForSeconds(5);
        GameObject.FindGameObjectWithTag("fader").GetComponent<fadeOut>().startFading();
        yield return new WaitForSeconds(3);
        text.text = "Nobody was able to fix her";
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Menu");
    }
}
