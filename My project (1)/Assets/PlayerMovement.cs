using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10;
    public float jumpHeight = 10.0f;

    private float horizontInput;
    private float vertInput;
    public float horizontalMultiplier = 1;

    public bool isGrounded;

    private CharacterController characterController;


    private Rigidbody rbody;

    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 horizontalMove = transform.forward * horizontInput * movementSpeed * Time.fixedDeltaTime * horizontalMultiplier;
        rbody.MovePosition(rbody.position + horizontalMove);

    }
    // Update is called once per frame
    void Update()
    {
        horizontInput = Input.GetAxis("Horizontal");
        //vertInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 400, 0));
        }
    }
}
