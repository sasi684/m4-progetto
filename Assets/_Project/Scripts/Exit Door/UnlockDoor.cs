using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour
{

    private bool _isOpen;
    private MeshRenderer[] _meshes;

    private void Awake()
    {
        _meshes = GetComponentsInParent<MeshRenderer>();
    }

    public void OpenFinalDoor(int coins, int totalCoins)
    {
        if(coins >= totalCoins)
        {
            _isOpen = true;

            foreach(var mesh in _meshes) mesh.material.color = Color.green;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isOpen && collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

}
