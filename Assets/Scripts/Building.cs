using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    LevelManager manager;
    SpriteRenderer sprite;
    Color oldColor;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<LevelManager>();
        sprite = GetComponent<SpriteRenderer>();
        oldColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (manager.canDelete)
        {
            Debug.Log("Delete Hover");
            sprite.color = oldColor + new Color(.35f, 0, 0);
        }
        else
            sprite.color = oldColor;
        if (Input.GetMouseButtonUp(0))
        {
            MouseClick();
        }
    }

    private void MouseClick()
    {
        if (FindObjectOfType<LevelManager>().canDelete)
        {
            FindObjectOfType<LevelManager>().canDelete = false;
            Destroy(gameObject);
        }
    }
}
