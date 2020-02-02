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
    public List<int> nullIndices;

    public GameObject salita;
    public GameObject discesa;

    [SerializeField]
    private List<float> levels;

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
        nullIndices = new List<int>();
        initializeSpaceAndNullIndices();
    }

    private void initializeSpaceAndNullIndices()
    {
        float currentX = startX;
        for (int i = 0; i < terrain.Count; i++)
        {
            if (terrain[i] == null)
                terrainLevels[i] = 0;
        }

        for (int i = 0; i < terrain.Count; i++, currentX += spriteLength)
        {
            if (terrain[i] != null)
            {
                GameObject obj = Instantiate(terrain[i], new Vector3(currentX, levels[terrainLevels[i] - 1], 0), terrain[i].transform.rotation);
                obj.GetComponent<fading>().setPosition(i);
                if(i < terrain.Count - 1 && terrainLevels[i + 1] == 0)
                {
                    terrainLevels[i + 1] = terrainLevels[i];
                }
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

    }

    public void insert(GameObject obj)
    {
        for(int i = 0; i < nullIndices.Count; i++)
        {
            if (terrain[nullIndices[i]] == null)
            {
                int levelIndex = findLevelIndex(obj, i);
                GameObject newInstance = Instantiate(obj, new Vector3(startX + nullIndices[i] * spriteLength, levels[levelIndex], 0), obj.transform.rotation);
                newInstance.GetComponent<fading>().setPosition(nullIndices[i]);
                terrainLevels[nullIndices[i]] = levelIndex + 1;
                terrain[nullIndices[i]] = newInstance;
                return;
            }
        }
    }

    private int findLevelIndex(GameObject obj, int i)
    {
        int levelModifier = terrain[nullIndices[i] - 1].GetComponent<levelModifier>().getLevelModifier();
        int levelIndex;
        if (terrainLevels[nullIndices[i]] == 0)
        {
            levelIndex = terrainLevels[nullIndices[i] - 1] - 1 + levelModifier;
        }
        else
        {
            levelIndex = terrainLevels[nullIndices[i]] - 1 + levelModifier;
        }

        if (levelIndex <= -1)
            return 0;
        if (levelIndex >= levels.Count)
            return levels.Count - 1;
        return levelIndex;
    }

    public void destroyLast()
    {
        for (int i = nullIndices.Count - 1; i >= 0; i--)
        {
            if (terrain[nullIndices[i]] != null)
            {
                Destroy(terrain[nullIndices[i]]);
                terrain[nullIndices[i]] = null;
                terrainLevels[nullIndices[i]] = 0;
                return;
            }
        }
    }

    public void setTerrainLevel(int position)
    {
        if (nullIndices.Contains(position - 1))
        {
            nullIndices.Remove(position - 1);
        }

        if (position == terrainLevels.Count || terrainLevels[position] != 0)
            return;
        terrainLevels[position] = terrainLevels[position - 1];
    }
}