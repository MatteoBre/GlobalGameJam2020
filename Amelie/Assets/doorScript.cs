using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().Play("doorAnim");
        StartCoroutine(ActivateParticles());
    }

    private IEnumerator ActivateParticles()
    {
        yield return new WaitForSeconds(1);
        particles.SetActive(true);
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("fader").GetComponent<fadeOut>().startFading();
    }
}
