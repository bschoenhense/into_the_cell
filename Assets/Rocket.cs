using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;
    bool audioToggle;

    [SerializeField] float thrust = 20f;
    float thrustThisFrame;

    [SerializeField] float rcsThrust = 200f;
    float rotationThisFrame;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag) {
            case "Friendly":
                print("Friendly");
                break;
            case "Hostile":
                print("Hostile");
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            thrustThisFrame = thrust * Time.deltaTime;
            rigidBody.AddRelativeForce(thrust * Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.freezeRotation = true;
            rotationThisFrame = rcsThrust * Time.deltaTime;
            transform.Rotate(rotationThisFrame * Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody.freezeRotation = true;
            rotationThisFrame = rcsThrust * Time.deltaTime;
            transform.Rotate(-rotationThisFrame * Vector3.forward);
        }

        rigidBody.freezeRotation = false;
    }
}
