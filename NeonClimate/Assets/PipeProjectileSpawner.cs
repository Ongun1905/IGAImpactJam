using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabPipeProjectile;
    [SerializeField] private Transform spawnPosPipe;
    [SerializeField] private Transform ProjectileFolder;
    private Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {

        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(TrashThrower());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TrashThrower()
    {
        while (Mathf.Abs(transform.position.y - PlayerTransform.position.y) < 10f)
        {
            float delay = Random.Range(1.8f, 2.5f);
            Debug.Log(delay);
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

