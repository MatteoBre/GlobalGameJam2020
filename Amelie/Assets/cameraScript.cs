using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public float startingSize;
    public float endSize;

    public float seconds;
    private float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed <= seconds)
            timeElapsed += Time.deltaTime;
        GetComponent<Camera>().orthographicSize = startingSize + (endSize - startingSize) * (timeElapsed / seconds);
    }
}
