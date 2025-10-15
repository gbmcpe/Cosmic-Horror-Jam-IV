using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOperator : MonoBehaviour
{
   public void NewGame()
{
      print("TestMessage");
SceneManager.LoadScene(1);
}

 public void QuitGame()
    {
     
    }
}
