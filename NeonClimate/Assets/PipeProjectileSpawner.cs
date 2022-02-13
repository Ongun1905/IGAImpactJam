using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabPipeProjectile;
    [SerializeField] private Transform spawnPosPipe;
    [SerializeField] private Transform ProjectileFolder;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TrashThrower());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TrashThrower()
    {
        while (true)
        {
            float delay = Random.Range(0.8f, 2.5f);
            //Debug.Log(delay);
            yield return new WaitForSeconds(delay);
            CreateProjectile();
        }
    }

    void CreateProjectile() 
    {
        var prefabProjectile = Instantiate(prefabPipeProjectile, spawnPosPipe.position, Quaternion.identity);
        prefabProjectile.transform.parent = ProjectileFolder;

    }

}

