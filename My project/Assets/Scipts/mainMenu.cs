
using UnityEngine.SceneManagement;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void Credits(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
    }
    public void PatchNotes(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +3);
    }
    public void FirstGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +4);
    }



}
