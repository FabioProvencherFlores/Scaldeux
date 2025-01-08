using Unity.Netcode;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    private bool _hasSpawned = false;
    [SerializeField] 
    private GameObject _playerPrefab;
    private GameObject _playerInstance;
    [SerializeField]
    private GameObject _genericCamera;
    private GameObject _fpsCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_hasSpawned)
        {
            _hasSpawned = true;
            Debug.Log("Spawn!");

            _playerInstance = Instantiate(_playerPrefab);
            _playerInstance.transform.position = Vector3.zero;

            PlayerControllerNetworked pcn = _playerInstance.gameObject.GetComponent<PlayerControllerNetworked>();

            // #todo fabio: ici sa devrait juste runner localement, pas repliquer
            _genericCamera.SetActive(false);
            pcn.GetFPSCamera().SetActive(true);

            NetworkObject networkObject = _playerInstance.GetComponent<NetworkObject>();
            networkObject.Spawn();
        }
    }
}
