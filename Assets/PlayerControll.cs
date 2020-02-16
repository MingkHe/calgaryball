using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;

    public float speed;
    public GameObject winText;
    public GameObject restartBtn;
    public AudioClip tada;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        winText.SetActive(false);
        restartBtn.SetActive(false);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndPoint"))
        {
            audioSource.PlayOneShot(tada, 0.5F);
            winText.SetActive(true);
            restartBtn.SetActive(true);
        }
    }
}
