using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCheck : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 worldPos;

    public Camera mainCamera;
    private RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        
        transform.position = worldPos;
    }

    private void OnMouseDrag()
    {
        mousePos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos = new Vector3(worldPos.x, worldPos.y, 0);
    }
    private void OnMouseUp()
    {
        Debug.Log(worldPos);
        Debug.Log("local: " + transform.localPosition);
    }
}
