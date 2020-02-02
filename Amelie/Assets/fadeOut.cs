using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeOut : MonoBehaviour
{
    private bool fade;
    private float fadeSeconds = 3;
    private float timeElapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().enabled = false;
        fade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
            timeElapsed += Time.deltaTime;
        GetComponent<Image>().color = new Color(1, 1, 1, 0f + timeElapsed / fadeSeconds);

        if(timeElapsed >= fadeSeconds)
        {
            //load scene
        }
    }

    public void startFading()
    {
        fade = true;
        GetComponent<Image>().enabled = true;
    }
}
