using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        sprite.color = Color.red;
    }

    private void OnMouseOver()
    {
        
    }

    private void OnMouseExit()
    {
        sprite.color = Color.white;
    }
}
