using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragNet : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    private int bookCounter;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(pos, new Vector2(0, 0), 0.01f);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.tag == "Book")
            {
                GameObject book = hits[i].collider.gameObject;
                Destroy(book);
                bookCounter++;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        transform.position = startPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        bookCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
