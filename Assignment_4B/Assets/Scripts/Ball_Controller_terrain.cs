using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Controller_terrain : MonoBehaviour
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

            if (IsBraketsBalanced(value))
            {
                collision.gameObject.SetActive(false);
                Debug.Log("Braket_balanced>>" + value);
                count++;
                SetCountText();
            }
            else
            {
                collision.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            }


        }
    }


    void SetCountText()
    {

        countText.text = "Count: " + count.ToString();

        Debug.Log("count>> " + CreateBlocks_Terian.correctLanguageCount);       
        if (count >= CreateBlocks_Terian.correctLanguageCount)
        {
            panel.SetActive(true);
            total_count.text = "Total Score: " + count.ToString();
        }
    }

    public static bool IsBraketsBalanced(string input)
    {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>() {
            { '(', ')' }
        };



        Stack<char> brackets = new Stack<char>();



        try
        {
            // Iterate through each character in the input string
            foreach (char c in input)
            {
                // check if the character is one of the 'opening' brackets
                if (bracketPairs.Keys.Contains(c))
                {
                    // if yes, push to stack
                    brackets.Push(c);
                }
                else
                // check if the character is one of the 'closing' brackets
                    if (bracketPairs.Values.Contains(c))
                {
                    // check if the closing bracket matches the 'latest' 'opening' bracket
                    if (c == bracketPairs[brackets.First()])
                    {
                        brackets.Pop();
                    }
                    else
                        // if not, its an unbalanced string
                        return false;
                }
                else
                    // continue looking
                    continue;
            }
        }
        catch
        {
            // an exception will be caught in case a closing bracket is found, 
            // before any opening bracket.
            // that implies, the string is not balanced. Return false
            return false;
        }



        // Ensure all brackets are closed
        return brackets.Count() == 0 ? true : false;
    }
}
