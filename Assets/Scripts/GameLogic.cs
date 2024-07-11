using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public TMP_InputField userInput;
    private int randomNum;
    public TMP_Text gameLabel;
    public int minVal = 0;
    public int maxVal = 21;
    public Button gameButton;
    private bool isGameWon = false;

    // Start is called before the first frame update
    void Start()
    {
       resetGame();
       
    }

    private void resetGame() {

        if (isGameWon) {
            gameLabel.text = "You Won Now Guess Again";
            isGameWon = false;
        }
        else {
            gameLabel.text = "Guess a Num between" + minVal + " & " + (maxVal - 1);
        }
        userInput.text = "";
        randomNum = getRandomNum(minVal, maxVal);
        
    }

    public void OnButtonClick() {
        string userInputValue = userInput.text;

        if (userInputValue != "")
        {
            int answer = int.Parse(userInputValue);


            if (answer == randomNum) {
                gameLabel.text = "Correct! You Win";
                // to disable button
                //gameButton.interactable = false; 
                isGameWon |= true;
                // to reset game
                resetGame();

                
            }
            else if (answer > randomNum) {
                gameLabel.text = "Try Lower!";
            }
            else{
                gameLabel.text = "Try higher!";
            }
        }
        else
        {
            gameLabel.text = "Plz Enter Number!";
        }

    }

    private int getRandomNum(int min, int max) { 
        int random = Random.Range(min, max);
        return random;
    }
}
