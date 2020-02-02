using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textRabbit : MonoBehaviour
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
        text.text = "Wake up Amelie!";
        yield return new WaitForSeconds(4);
        text.text = "Are you here? Can you hear me?";
        yield return new WaitForSeconds(5);
        text.text = "On this path you will find books that belong to your story";
        yield return new WaitForSeconds(7);
        text.text = "You have to recover your memories, only then you will be able to find yourself";
        yield return new WaitForSeconds(8);
        text.text = "Be careful! Your journey will not be easy, the path is broken, fix it with your creativity";
        yield return new WaitForSeconds(9);
        SceneManager.LoadScene("StartingLevel");
    }
}
