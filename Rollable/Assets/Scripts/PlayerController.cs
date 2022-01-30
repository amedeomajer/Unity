using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 0;
	public TextMeshProUGUI CountText;
	public GameObject winTextObject;
	public GameObject NorthWallObject;

    private Rigidbody rb;
	private int count;



    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		count = 0;

		SetCountText();
		winTextObject.SetActive(false);
	}

	private void Update()
	{
		if (gameObject.transform.position.y <= -9) //If my position has changed from my original position:
        {
			//RestartLevel(); 
			if (NorthWallObject.active == false)
			{

			}
			SceneManager.LoadScene(Application.loadedLevel);
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

	void SetCountText()
	{
		CountText.text = "Points: " + count.ToString();
		if (count == 16)
		{
			NorthWallObject.SetActive(false);
		}
		if (count == 50)
		{
			winTextObject.SetActive(true);
			
		}
	}
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
				other.gameObject.SetActive(false);
				count = count + 1;
				SetCountText();
		}
	}
	void RestartLevel() //Restarts the level
	{
  		SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
	}
}
