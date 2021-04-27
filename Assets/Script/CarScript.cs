using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject Buster;
    public Image BootsterIndicator;

    public float Speed;
    public float Rotation;


    private float rot;
    private bool BustoerFlag;


    [SerializeField] private float BoosterValue;

    private void Start()
    {
        Buster.SetActive(false);
        BootsterIndicator.fillAmount = 0f;
        Physics.IgnoreLayerCollision(0, 8);
        rb = GetComponent<Rigidbody2D>();
        float scrensixe = Screen.width;
        Debug.Log(scrensixe/2);



        if (true)
        {

        }
    }


    private void Update()
    {
        InputMethod();
          SpeedAdjustMethod();

        BootsterIndicator.fillAmount = BoosterValue/6;

    }

    public void BustoerOn()
    {



        Buster.SetActive(true);


        BustoerFlag = true;
        Debug.Log("ButerOn"+BustoerFlag);
    }
    public void BusterOff()
    {
        Buster.SetActive(false);
        Debug.Log("ButerOff"+BustoerFlag);
        BustoerFlag = false;
    }

    public void LelftClickPress()
    {
        rot = Rotation;
    }
    public void LelftClickRealse()
    {
        rot = 0f;
    }


    public void RightClickPress()
    {
        rot = -Rotation;
    }

    public void RightClickRealse()
    {
        rot = 0;
    }


    private void InputMethod()
    {
        //if (Input.GetMouseButton(0) && !BustoerFlag)
        //{

        //    Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    if (MousePos.x > 0)
        //    {
        //        rot = -Rotation;
        //    }
        //    else
        //    {
        //        rot = Rotation;
        //    }
            transform.Rotate(0, 0, rot);

        //}        //}        //}
        //if (Input.touchCount == 1&&!BustoerFlag)
        //{
        //    var touch = Input.touches[0];
        //    if (touch.position.x < Screen.width / 2)
        //    {
        //        rot = Rotation;
        //        Debug.Log("Lefttouch");
        //    }
        //    else if (touch.position.x > Screen.width / 2)
        //    {
        //        Debug.Log("Righttouch");
        //        rot = -Rotation;
        //    }
        //    transform.Rotate(0, 0, rot);
        //}
    }

    private void SpeedAdjustMethod()
    {
        if (BustoerFlag&& BoosterValue >= 0)
        {
         
               
                rb.velocity = transform.up * Speed * 5f;
                BoosterValue-=0.02f;
            
       
        }
        else
        {
            Buster.SetActive(false);
            rb.velocity = transform.up * Speed;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Booster")
        {
            if (BoosterValue<6f)
            {
                BoosterValue += 2f;
            }
        
            Debug.Log("Ebter");
            Destroy(collision.gameObject);
       
        }
    }
}
