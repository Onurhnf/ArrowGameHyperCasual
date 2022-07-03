using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathThings : MonoBehaviour
{
    System.Data.DataTable table = new System.Data.DataTable();
    string result;
    float floatResult = 0f;
    public Image endGame;
    public Text textt,textScore;
    float highestScore=0f;
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            if (!gameObject.CompareTag("Finish"))
            {

                result = other.transform.parent.GetChild(1).GetComponent<TextMesh>().text + gameObject.transform.GetChild(0).GetComponent<TextMesh>().text;
                other.transform.parent.GetChild(1).GetComponent<TextMesh>().text = "" + table.Compute(result, "");

                
                
            }
            floatResult = float.Parse(other.transform.parent.GetChild(1).GetComponent<TextMesh>().text);

            if (floatResult<=0f)
            {
                
                Time.timeScale = 0f;
                endGame.gameObject.SetActive(true);
                textt.text = "Failed! Your score:" + floatResult;
                sound.Pause();


            }
            else if (gameObject.name.Equals("Finish"))
            {
                
                Time.timeScale = 0f;
                endGame.gameObject.SetActive(true);
                textt.text = "Your score:" + floatResult;
                sound.Pause();
            }

            if (highestScore<floatResult)
            {
                highestScore = floatResult;
                PlayerPrefs.SetFloat("highscore", highestScore);
            }



        }
        
    }
    private void Start()
    {

        textScore.text = $" Best Score: {PlayerPrefs.GetFloat("highscore")}";
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); 
    }
}
