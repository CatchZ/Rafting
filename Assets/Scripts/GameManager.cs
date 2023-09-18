using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Leben des Spielers
    /// </summary>
    /// 
    public int maxLeben = 100;
    public int leben = 100;
    public int material = 0;
    public bool isGameActive;
    public GameObject menue;
    public GameObject ingameUi;
    public int repairValue = 20;
    public int repairCost = -100;
   

    public TextMeshProUGUI lebenText;
    public TextMeshProUGUI materialText;
    public Button startButton;
    public TextMeshProUGUI repairText;
    // Start is called before the first frame update
    void Start()
    {
        menue.gameObject.SetActive(false);
        ingameUi.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// changes live value of the Player by additon
    /// </summary>
    /// <param name="veraenderung">betrag des Lebens</param>
    public void UpdateLeben(int veraenderung)
    {
        leben += veraenderung;
        lebenText.text = "Leben: " + leben;
    }

    public void GameOverCheck()
    {
        if (leben < 1)
        {
            menue.gameObject.SetActive(true);
            isGameActive = false;
        }

    }
    public void StartGame()
    {
        isGameActive = true;
        startButton.gameObject.SetActive(false);
        UpdateLeben(0);
        UpdateMaterial(0);
        menue.gameObject.SetActive(false);
        ingameUi.gameObject.SetActive(true);
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void UpdateMaterial(int veraenderung)
    {
        material += veraenderung;
        materialText.text = "Material: " + material;
    }
    public void Repair()
    {
        if(leben >= 100) {
          
        }else
        if (leben > 80&&material > -repairCost) {
            leben = maxLeben;
            UpdateMaterial(repairCost);
            repairText.text = "Reparieren";
        }
        else 
        if (material >= -repairCost)
        {
            UpdateMaterial(repairCost);
            
            UpdateLeben(repairValue);
            repairText.text = "Reparieren";

        }
        else { repairText.text = "Reparieren(Kosten:" + repairCost + ")"; }


    }
}
