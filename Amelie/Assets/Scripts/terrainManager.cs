using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainManager : MonoBehaviour
{
    //terrain and terrainLevels need to be the same size as one represents the height of the object and the other represent the object
    [SerializeField]
    private List<GameObject> terrain;
    [SerializeField]
    private List<int> terrainLevels;
    private List<int> nullIndices;

    [SerializeField]
    private List<float> levels;

    private int lastInsertedPosition;

    //sprite variables
    [SerializeField]
    private float spriteLength;

    [SerializeField]
    private float startX;

    [SerializeField]
    private float fixedY;

    // Start is called before the first frame update
    void Start()
    {
        lastInsertedPosition = -1;
        nullIndices = new List<int>();
        initializeSpaceAndNullIndices();
    }

    private void initializeSpaceAndNullIndices()
    {
        float currentX = startX;
        for (int i = 0; i < terrain.Count; i++, currentX += spriteLength)
        {
            if (terrain[i] != null)
            {
                Instantiate(terrain[i], new Vector3(currentX, levels[terrainLevels[i]], 0), Quaternion.identity);
            }
            else
            {
                nullIndices.Add(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            insert(terrain[0]);
        if (Input.GetKeyDown(KeyCode.G))
            destroyLast();
    }

    public void insert(GameObject obj)
    {
        for(int i = 0; i < nullIndices.Count; i++)
        {
            if (terrain[nullIndices[i]] == null)
            {
                GameObject newInstance = Instantiate(obj, new Vector3(startX + nullIndices[i] * spriteLength, fixedY, 0), Quaternion.identity);
                terrain[nullIndices[i]] = newInstance;
                lastInsertedPosition = nullIndices[i];
                return;
            }
        }
    }

    public void destroyLast()
    {
        for (int i = nullIndices.Count - 1; i >= 0; i--)
        {
            if (terrain[nullIndices[i]] != null)
            {
                Destroy(terrain[nullIndices[i]]);
                terrain[nullIndices[i]] = null;
                return;
            }
        }
    }
}