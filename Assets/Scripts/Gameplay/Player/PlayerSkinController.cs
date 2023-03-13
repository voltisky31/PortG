using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinController : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerData;
    private Transform spawnedSkin;

    private void Awake()
    {
        if(ReferenceEquals(PlayerData.SelectedSkin, null))
        {
            Debug.LogError("You neeed to select skin!!!");
            return;
        }

        spawnedSkin = Instantiate(PlayerData.SelectedSkin, transform);
    }

}
