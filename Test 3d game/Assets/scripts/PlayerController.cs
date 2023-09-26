using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public GameObject WinText;

    private int _count;

    private Rigidbody _playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody= GetComponent<Rigidbody>();
        _count=0;
        CountText.text = "Count: " + _count.ToString();
        WinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput;
        float verticalInput;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        _playerRigidbody.AddForce(movement);
    }
    
    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            CountText.text = "Count: " + _count.ToString();

            if (_count >= 8)
            {
                WinText.gameObject.SetActive(true);
            }
        }
    }
}
