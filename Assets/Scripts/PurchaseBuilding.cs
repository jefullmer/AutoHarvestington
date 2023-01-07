using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseBuilding : MonoBehaviour
{
    public GameObject newBuilding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject building = Instantiate(newBuilding);
            building.GetComponent<PlaceBuilding>().followCursor = true;
        }
    }
}
