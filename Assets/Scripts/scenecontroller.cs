using UnityEngine;
using UnityEngine.SceneManagement; // Tambahkan namespace ini

public class scenecontroller : MonoBehaviour
{
    public void open_scene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);  
    }
}