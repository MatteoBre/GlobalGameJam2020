using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    [SerializeField]
    private GameObject objToFollow;

    private float minX;
    [SerializeField]
    private float maxX;

    [SerializeField]
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        minX = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Max(objToFollow.transform.position.x, minX) + offset.x, offset.y, offset.z); // Camera follows the player with specified offset position
    }
}
