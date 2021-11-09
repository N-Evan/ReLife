//unused for now. 

using UnityEngine;
using UnityEngine.SceneManagement;

public class leveLoader : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        LoadScene();
    }

    void LoadScene()
    {
        FindObjectOfType<AudioManager>().Play("levelComplete");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
