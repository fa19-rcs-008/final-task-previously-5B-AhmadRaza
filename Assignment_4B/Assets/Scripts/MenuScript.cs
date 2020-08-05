using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject panelofmainmenu;
    public GameObject panelofmlagents;
    public GameObject panelofMenu;
    public GameObject panelofpalindrome;
    public GameObject panelofparenthesis;
    public GameObject panelforpalindromelan;
    public GameObject panelforparenthesislan;
    public GameObject panelforlearningOutline;
    public string url;

    // Start is called before the first frame update
    void Start()
    {
        panelofmainmenu.SetActive(true);
    }

    public void mainmenu()
    {
        panelofMenu.SetActive(true);
        panelofmainmenu.SetActive(false);
    }

    public void ListOfLearning()
    {
        panelforlearningOutline.SetActive(true);
        panelofmainmenu.SetActive(false);
    }

    public void instructorLink()
    {
        panelofMenu.SetActive(true);
        panelofmainmenu.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void Mlagent()
    {
        panelofMenu.SetActive(false);
        panelofmlagents.SetActive(true);

    }

    public void computationalModel()
    {
        panelofpalindrome.SetActive(true);
        panelofMenu.SetActive(false);
    }

    public void matchingPrenthesis()
    {
        panelofparenthesis.SetActive(true);
        panelofMenu.SetActive(false);
    }
    public void backtomainMenu()
    {
        panelofmainmenu.SetActive(true);
        panelofMenu.SetActive(false);
    }

    public void Penguingame()
    {
        SceneManager.LoadScene("Penguin_Train");
    }
    public void Hummingbird()
    {
        SceneManager.LoadScene("FlowerIsland");

    }


    public void back_to_menu()
    {
        panelofmlagents.SetActive(false);
        panelofMenu.SetActive(true);

    }
    public void LanguagePlendrome()
    {
        panelforpalindromelan.SetActive(true);
        panelofpalindrome.SetActive(false);
    }
    public void palindromeWord()
    {
        SceneManager.LoadScene("Roll_Bal");
    }
    public void backToComputational()
    {
        panelofMenu.SetActive(true);
        panelofpalindrome.SetActive(false);
    }

    public void Parenthesislanguage()
    {
        panelforparenthesislan.SetActive(true);
        panelofparenthesis.SetActive(false);
    }
    public void ParenthesisWord()
    {
        SceneManager.LoadScene("Roll_Bal_2");
    }

    public void backTOParenthesis()
    {
        panelofMenu.SetActive(true);
        panelofparenthesis.SetActive(false);
    }

    public void bacfromPalindromeLang()
    {
        panelofpalindrome.SetActive(true);
        panelforpalindromelan.SetActive(false);
    }

    public void bacfromPranthesesLang()
    {
        panelofparenthesis.SetActive(true);
        panelforparenthesislan.SetActive(false);
    }

    public void bacfromlistOf()
    {
        panelofmainmenu.SetActive(true);
        panelforlearningOutline.SetActive(false);
    }

}
