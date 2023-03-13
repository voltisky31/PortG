using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSkin : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Transform skinPrefab;

    Controls controls;

    private void Awake()
    {
        controls = new Controls();
        controls.Menu.SelectSkinPressed.performed += ctx => SelectSkinPressed();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void SelectSkinPressed()
    {
        playerData.SelectedSkin = skinPrefab;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
