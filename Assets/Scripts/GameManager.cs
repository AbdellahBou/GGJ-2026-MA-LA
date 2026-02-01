using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject abilityPrefb;
    [SerializeField]
    private GameObject particalPrefb;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 maskScale;
    [SerializeField]
    private List<Transform> SpawnPoint;
    [SerializeField]
    private AudioClip bgMusic;
    [SerializeField]
    private AudioSource audioSources;
    GameObject maskAbility;
    GameObject particless;

    private void Start()
    {
        int randPos = Random.Range(0, SpawnPoint.Count );
        maskAbility =  Instantiate(abilityPrefb, SpawnPoint[randPos].position, Quaternion.identity);
        particless = Instantiate(particalPrefb, SpawnPoint[randPos].position + offset, Quaternion.identity);
        maskAbility.transform.localScale = maskScale;
        maskAbility.transform.eulerAngles = new Vector3(0f,0f,-180f);
        audioSources.volume = 0.3f;
        audioSources.Play();
    }
    private void Update()
    {
        if (maskAbility == null)
        {
            Destroy(particless);
        }
    }

}
