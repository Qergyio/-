using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity;
public class Star : MonoBehaviour
{
    public Vector3 velocity { get; set; }
    public Vector3 acceleration { get; set; }


    // Start is called before the first frame update
    // Update is called once per frame
    public void UpdatePosition(Galaxy galaxy, float smoothLenght)
    {
        acceleration = Vector3.zero;
        foreach (Star star in galaxy.Stars)
        {
            if (star != this)
            {
                acceleration += (star.transform.position - transform.position).normalized / (MathF.Pow(Vector3.Distance(transform.position, star.transform.position), 2) + smoothLenght);
            }
        }
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity;
        CameraView();
    }
    public void CameraView()
    {
        transform.rotation = Camera.main.transform.rotation;
        CameraMovement cameraMovement = Camera.main.GetComponent<CameraMovement>();
        transform.localScale = new Vector3(cameraMovement.DistanceToTarget / 800f, cameraMovement.DistanceToTarget / 800f);
        //orange if velocity is low and blue if velocity is high progressively
        
    }




}
