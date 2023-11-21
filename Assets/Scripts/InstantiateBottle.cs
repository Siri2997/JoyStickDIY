using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBottle : MonoBehaviour
{
    public Camera cam;
    //[Space]
    public bool mouseSingleClick;
    //[Space]
    //public Color paintColor;
    public GameObject bottle;
    private Vector3 startPos, startEulerAngles;
    public int MouseClickCount;
    
    // Start is called before the first frame update
    void Start()
    {
       
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
                if (hit.transform.CompareTag("SprayBottle"))
                {
                    startPos = hit.transform.position;
                    startEulerAngles = hit.transform.eulerAngles;
                    bottle.GetComponent<MeshRenderer>().material = hit.transform.GetComponent<MeshRenderer>().material;
                    Debug.Log("Did Hit");

                    //Particle
                    ParticleSystem bottle_Ps = bottle.GetComponentInChildren<ParticleSystem>();
                    var main = bottle_Ps.main;
                    if (hit.transform.name == "Red_bottle")
                    {
                        bottle.GetComponentInChildren<ParticleSystem>().GetComponent<ParticlesController>().paintColor = Color.red;
                        main.startColor= Color.red;
                    }

                    if (hit.transform.name == "Yellow_bottle")
                    {
                        bottle.GetComponentInChildren<ParticleSystem>().GetComponent<ParticlesController>().paintColor = Color.yellow;
                        main.startColor= Color.yellow;
                    }


                    if (hit.transform.name == "Blue_bottle")
                    {
                        bottle.GetComponentInChildren<ParticleSystem>().GetComponent<ParticlesController>().paintColor = Color.blue;
                        main.startColor = Color.blue;
                    }

                     if (hit.transform.name == "Green_bottle")
                    {
                        bottle.GetComponentInChildren<ParticleSystem>().GetComponent<ParticlesController>().paintColor = Color.green;
                        main.startColor = Color.green;

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

    private void OnCollisionStay(Collision other)
    {

        
    }
}
