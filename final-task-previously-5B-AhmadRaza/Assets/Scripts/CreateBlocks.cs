using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;    
using System.Linq;
using TMPro;

public class CreateBlocks : MonoBehaviour
{    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    private Vector3 Cubes;
    private float radius = 1;
    private int numCubes = 10;
    public static bool tf;
    private static System.Random random = new System.Random();
    public static int pelindromeCount;



    // Start is called before the first frame update
    void Start()
    {

        List<string> results = createPalindrome();
        Debug.Log("String genrated >>");
        int i = 0;
        while (numCubes > 0)
        {


            Cubes = new Vector3(UnityEngine.Random.Range(-18, 18), UnityEngine.Random.Range(1.1f, 1.1f), UnityEngine.Random.Range(-18, 18));


            if (Physics.CheckSphere(Cubes, radius))
            {

            }
            else
            {
                Instantiate(myPrefab, Cubes, Quaternion.identity);
                myPrefab.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = results[i];
                i++;
                numCubes = numCubes - 1;
            }

        }

    }


    public List<string> createPalindrome()
    {
        List<string> randomStrings = RandomString();
        int count = 0;
        pelindromeCount = UnityEngine.Random.Range(3, 9);
        Debug.Log("Pelindrome ccount>>" + pelindromeCount);
        for (int i = 0; i < pelindromeCount; i++)
        {
            count++;
            string first = randomStrings[i].Substring(0, randomStrings[i].Length / 2);
            char[] arr = first.ToCharArray();
            Array.Reverse(arr);
            string temp = new string(arr);
            randomStrings[i] = first + temp;
            string value = randomStrings[i];
        }

        return randomStrings;
    }


    public static List<string> RandomString()
    {
        List<string> list_of_strings = new List<string>();
        int x;
        for (int i = 0; i <= 10; i++)
        {
            x = UnityEngine.Random.Range(9, 15);
            const string chars = "XA8";
            string val = new string(Enumerable.Repeat(chars, 11)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            list_of_strings.Add(val);

        }

        return list_of_strings;
    }

   
    // Update is called once per frame
    void Update()
    {

    }
}
