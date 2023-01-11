using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    public bool followCursor;

    bool canPlace;
    float waitTimer;
    List<GameObject> inCollision;
    SpriteRenderer sprite;
    Color oldColor;

    // Start is called before the first frame update
    void Start()
    {
        canPlace = true;
        waitTimer = 0;
        inCollision = new List<GameObject>();
        sprite = GetComponent<SpriteRenderer>();
        oldColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer += Time.deltaTime;
        if (followCursor)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            Snap();
        }
        if (Input.GetMouseButtonUp(0) && waitTimer >= .25f && canPlace)
        {
            followCursor = false;
        }
    }

    private void Snap()
    {
        float gridSize = FindObjectOfType<GlobalVars>().spacing;
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x / gridSize) * gridSize, Mathf.RoundToInt(transform.position.y / gridSize) * gridSize);
        CheckCanPlace();
    }

    private void CheckCanPlace()
    {
        int gridPieces = 0;
        for(int i = 0; i < inCollision.Count; i++)
        {
            if (inCollision[i].GetComponent<PlaceBuilding>())
            {
                canPlace = false;
                sprite.color = oldColor + new Color(.35f, 0, 0);
                return;
            }
            if (inCollision[i].GetComponent<GridScript>())
                gridPieces++;
        }
        
        if (gridPieces != 4)
        {
            canPlace = false;
            sprite.color = oldColor + new Color(.35f, 0, 0);
            return;
        }

        canPlace = true;
        sprite.color = oldColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inCollision.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inCollision.Remove(collision.gameObject);
    }
}
