using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text total_count;
    private Rigidbody rb;
    public GameObject panel;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        total_count.text = "";
        panel.SetActive(false);
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision accour");
        if (collision.gameObject.CompareTag("Pick Up"))
        {

            string value = collision.gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text.ToString();

            if (IsPalindrome(value))
            {
                collision.gameObject.SetActive(false);
                Debug.Log("pelendrom>>" + value);
                count++;
                SetCountText();
            }
            else {
                collision.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            }


        }
    }


    void SetCountText()
    {
        
        countText.text = "Count: " + count.ToString();
       
        Debug.Log("count>> " + CreateBlocks.pelindromeCount);
        if (count >= CreateBlocks.pelindromeCount)
        {
            panel.SetActive(true);
            total_count.text = "Total Score: " + count.ToString();
        }
    }

    public static bool IsPalindrome(string text)
    {
        if (text.Length <= 1)
            return true;
        else
        {
            if (text[0] != text[text.Length - 1])
                return false;
            else
                return IsPalindrome(text.Substring(1, text.Length - 2));
        }
    }
}
