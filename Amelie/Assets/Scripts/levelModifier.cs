using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelModifier : MonoBehaviour
{
    [SerializeField]
    private int modifier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getLevelModifier()
    {
        return modifier;
    }
}
