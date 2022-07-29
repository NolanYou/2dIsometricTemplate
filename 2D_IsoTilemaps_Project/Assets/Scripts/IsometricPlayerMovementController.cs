using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IsometricPlayerMovementController : MonoBehaviour
{
    const float movementSpeed = 10;
    
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;
 
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        rbody.isKinematic = false;
        rbody.drag = 5;
        rbody.useAutoMass = true;
        rbody.velocity = new Vector2(0,0);
    }


    // Update is called once per frame
    void FixedUpdate()
    {   
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        
        
        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        

        Vector2 movement = movementSpeed * Time.deltaTime * inputVector;
        rbody.drag = Math.Max(5, rbody.velocity.magnitude * 0.2f);

        rbody.AddForce(movement);
        // rbody.velocity = movement;
        // Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        // rbody.MovePosition(newPos);
        Debug.Log("Schmoobment speed" + rbody.GetPointVelocity(new Vector2(0,0)));
    }
}
