using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleMovement : MonoBehaviour
{
    private Vector3 moffset;
    float mzCoord;
    public int MouseClickCount =0;
    public Camera cam;
    //[Space]
    private bool mouseSingleClick;
    private Vector3 firstPos;
    private Vector3 firstEulerAngles;
    
    // Start is called before the first frame update
    void Start()
    {
        firstPos = this.transform.localPosition;
        firstEulerAngles = this.transform.localEulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool click = mouseSingleClick ? Input.GetMouseButtonDown(0) : Input.GetMouseButton(0);
        Vector3 position = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(position);

        RaycastHit hit;
        if (click)
        {
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.CompareTag("PaintBottle"))
                {
                    Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);
                    Debug.Log("Did Hit");
                    MouseClickCount++;
                    if (MouseClickCount >= 1)
                    {
                        hit.transform.GetComponentInChildren<ParticleSystem>().Play();
                    }
                }
            }

            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
                MouseClickCount = 0;
                //hit.transform.GetComponentInChildren<ParticleSystem>().Stop();
            }

        }

    }

    private void OnMouseDown()
    {
        mzCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        moffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mzCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + moffset;
        
    }

}
