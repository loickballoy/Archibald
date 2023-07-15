using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public Camera _camera;
    public Vector3 mouse;

    public List<Transform> coins = new List<Transform>();
    public List<Transform> components = new List<Transform>();

    public List<Transform> stimpacks = new List<Transform>();
    public List<Transform> stimics = new List<Transform>();
    public List<Transform> weapons = new List<Transform>();
    public List<Transform> experiences = new List<Transform>();

    public List<Transform> armures = new List<Transform>();
    public float mouseAngle;
    public float turboFloat=0.5f;
    private float turboTime=0f;
    public bool turboBool;

    void Start()
    {
        mouseAngle = Vector3.Angle(mouse, new Vector3(1, 0, 0));
        mouse = Input.mousePosition-new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0.0f);
    }

    void Update()
    {
        turboTime += Time.deltaTime;
        if(turboTime>turboFloat)
        {
          turboTime = 0f;
          turboBool = !turboBool;
        }

        mouse = Input.mousePosition-new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0.0f);
		    mouseAngle = Vector3.Angle(mouse, new Vector3(1, 0, 0));
        mouseAngle *= mouse.y < 0? -1 : 1;

    }
}
