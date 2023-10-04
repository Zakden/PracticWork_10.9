using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityController : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "PracticWork_10.9.1")
            Physics.gravity = new Vector3(0, -9.81f, 0);
        else
            Physics.gravity = new Vector3(0, -9.81f, -9.81f);
    }
}
