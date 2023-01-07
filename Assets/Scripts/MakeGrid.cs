using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGrid : MonoBehaviour
{
    public GameObject gridObject;
    public int gridX;
    public int gridY;
    float spacing;

    // Start is called before the first frame update
    void Start()
    {
        spacing = FindObjectOfType<GlobalVars>().spacing;
        EstablishGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EstablishGrid()
    {
        for (int i = 0; i < gridX; i++)
        {
            for (int j = 0; j < gridY; j++)
            {
                Vector3 newPosition = new Vector3(i * spacing, -j * spacing) + transform.position + new Vector3(spacing/2, -spacing/2);
                Instantiate(gridObject, newPosition, Quaternion.identity, transform);
            }
        }
    }
}
