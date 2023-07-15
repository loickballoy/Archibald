using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCtrl : MonoBehaviour
{
    private Vector3 startingPos = Vector3.zero;

    public float speed;
    public float sensitivity;
    private Vector2 movePos;

    public int maxX;
    public int maxY;
    public int minX;
    public int minY;

    // Start is called before the first frame update
    void Start()
    {
        //SetHeart();
    }

    public void SetHeart()
    {
        transform.position = startingPos;
        movePos = startingPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * sensitivity;
        float vertical = Input.GetAxis("Vertical") * sensitivity;

        movePos.x += horizontal;
        movePos.y += vertical;

        movePos.x = Mathf.Clamp(horizontal, minX, maxX);
        movePos.y = Mathf.Clamp(vertical, minY, maxY);

        transform.position = Vector2.Lerp(transform.position, movePos, speed * Time.deltaTime);
    }
}
