using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroungManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 initialPosition;

    [SerializeField]
    private float length;
    private float nextX;
    [SerializeField]
    private float offsetX;
    private float fixedY;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(background, initialPosition, Quaternion.identity);
        nextX = initialPosition.x + length;
        fixedY = initialPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x + offsetX >= nextX)
        {
            Instantiate(background, new Vector3(nextX, fixedY, 0), Quaternion.identity);
            nextX += length;
        }
    }
}
