using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    private AudioSource audioSource;
    public float volume = 0.5f;
    public bool birdIsAlive = true;
    public Animator animator;
    bool jump = false;
    public float additionalSpeed = 0.1f;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    void Update()
    {
        if ((Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * (flapStrength + additionalSpeed);
            jump = true;
            animator.SetBool("Jumping", true);
        }
        else
        {
            jump = false;
            animator.SetBool("Jumping", false);
        }

        if (transform.position.y > 17 || transform.position.y < -17)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        audioSource.Play();
    }
}
