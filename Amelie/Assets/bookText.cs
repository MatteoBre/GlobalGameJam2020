using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bookText : MonoBehaviour
{
    private dragNet bookCounter;
    // Start is called before the first frame update
    void Start()
    {
        bookCounter = GameObject.FindGameObjectWithTag("BookCounter").GetComponent<dragNet>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Books: " + bookCounter.getCurrentBooksCount() + "/" + bookCounter.getTotalBooksCount();
    }
}
