using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject particles;
    [SerializeField]
    private string sceneToLoad;
    private dragNet bookCounter;
    // Start is called before the first frame update
    void Start()
    {
        particles.SetActive(false);
        bookCounter = GameObject.FindGameObjectWithTag("BookCounter").GetComponent<dragNet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool allBooks = bookCounter.getCurrentBooksCount() >= bookCounter.getTotalBooksCount();
        if (allBooks)
        {
            GetComponent<Animator>().Play("doorAnim");
            StartCoroutine(ActivateParticles());
        }
    }

    private IEnumerator ActivateParticles()
    {
        yield return new WaitForSeconds(1);
        particles.SetActive(true);
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("fader").GetComponent<fadeOut>().startFading();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneToLoad);
    }
}
