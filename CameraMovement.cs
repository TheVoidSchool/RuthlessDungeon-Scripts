using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speed = 20;
    private Vector2 motion;
    public Map map;

    public Camera cam;

    public int zoom = 1;


    public void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {

        motion.x = 0;
        motion.y = 0;

        if (cam.transform.position.x <= map.mapSize)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                motion.x = Input.GetAxisRaw("Horizontal");
            }
        }
        if (cam.transform.position.y <= map.mapSize)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                motion.y = Input.GetAxisRaw("Vertical");
            }
        }
        if (cam.transform.position.x >= 0)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                motion.x = Input.GetAxisRaw("Horizontal");
            }
        }
        if (cam.transform.position.y >= 0)
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                motion.y = Input.GetAxisRaw("Vertical");
            }
        }

        transform.Translate(motion * (cam.orthographicSize/5) * speed * Time.deltaTime);

        if (cam.orthographicSize > 0 && cam.orthographicSize < 13)
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0f) // forward
            {
                cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
            }
        }
        else if (cam.orthographicSize <= 0)
        {
            cam.orthographicSize = 1;
        }
        else if (cam.orthographicSize >= 13)
        {
            cam.orthographicSize = 12;
        }
    }
}