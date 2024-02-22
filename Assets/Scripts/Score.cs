
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreDisplay;
    public int threeStars = 3;
    public int twoStars = 5;
    public Animator scoreAnimator;
    public int nextLevel = 0;

    public void EndLevel()
    {
        Cannon cannon = FindObjectOfType<Cannon>();
        if (cannon)
        {
            int numProjectiles = cannon.numProjectiles;

            if (numProjectiles < threeStars)
            {
                // Reward the player 3 stars when the player launches few cannonballs.
                print("Three Stars!");
                scoreDisplay.text = "Three Stars!";
                scoreAnimator.SetInteger("Stars", 3);
            }

            else if (numProjectiles < twoStars)
            {
                // Reward the player 2 stars when the player launches a little more than a few cannonballs.
                print("Two Stars!");
                scoreDisplay.text = "Two Stars!";
                scoreAnimator.SetInteger("Stars", 2);
            }

            else
            {
                // Reward the player 1 star whe the player launches many cannonballs.
                print("One Star!");
                scoreDisplay.text = "One Star!";
                scoreAnimator.SetInteger("Stars", 1);
            }
            Invoke("NextLevel",2);
        }
    }
    // spawn next level after star score shows
    void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
