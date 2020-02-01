using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private int health = 5;
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Amelie's Health: " + health;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health++;
        }

    }
}
