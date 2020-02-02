using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSprite : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> spriteList;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriteList[Random.Range(0, spriteList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
