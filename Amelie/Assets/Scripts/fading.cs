﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fading : MonoBehaviour
{
    [SerializeField]
    private float seconds;
    private float elapsed;

    private bool countDown;

    private int position;

    // Start is called before the first frame update
    void Start()
    {
        countDown = false;
        elapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= seconds)
            {
                StartCoroutine(destroyGameObject());
            }
            updateSprites();
        }
    }

    IEnumerator destroyGameObject()
    {
        destroyChildrenAndDisableColliders();
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void destroyChildrenAndDisableColliders()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
           Destroy(transform.GetChild(i).gameObject);
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
    }

    private void updateSprites()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1f - elapsed/seconds);
        }
    }

    public void activateCountDown()
    {
        countDown = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag=="Cloud")
            activateCountDown();
        GameObject worldGenerator = GameObject.FindGameObjectWithTag("worldGenerator");
        worldGenerator.GetComponent<terrainManager>().setTerrainLevel(position + 1);
    }

    public void setPosition(int position)
    {
        this.position = position;
    }
}
