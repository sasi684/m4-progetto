using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<PlayerController>(out var player))
            SceneManager.LoadScene("Defeat Scene");
    }

}
