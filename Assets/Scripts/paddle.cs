using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    Vector3 padPos = new Vector3();
    public GameObject myPaddle;
    public GameObject myBall;
    public GameObject particle;

    private float accelerationPad = 5f;
    private int direction = 0;
   


    void Start()
    {
        padPos = myPaddle.GetComponent<Transform>().position;
    }

    void Update()
    {
        //Debug.Log(padPos); 
    }

    private void FixedUpdate()
    {
        padMove();
    }

    private void padMove()
    {
        direction = 0;
        if (Input.GetKey(KeyCode.RightArrow))    
            direction = 1;   
        else
            if (Input.GetKey(KeyCode.LeftArrow))
                direction = -1;
        if (Mathf.Abs(padPos.x) < Screen.width / 2)
        {
            myPaddle.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + direction * 0.25f);
            padPos.x += direction * (accelerationPad * Time.deltaTime);
            myPaddle.transform.position = padPos;
        }
    }
}
