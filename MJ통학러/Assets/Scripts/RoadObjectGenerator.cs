using UnityEngine;

public class RoadObjectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] humans;

    private AudioManager _audioManager;

    private GameObject _newMob;
    private Quaternion rotation;
    
    private void Start()
    {
        var startDelay = Random.Range(0f, 5f);
        var delay = Random.Range(12f, 16f);
        _audioManager = FindObjectOfType<AudioManager>();
        _audioManager.Play("Sound");

        rotation = Quaternion.Euler(0, 0, 0);

        if (transform.position.x == 10)
        {
            rotation = Quaternion.Euler(0, 180, 0);
        }
        InvokeRepeating(nameof(GenerateMob), startDelay, delay);
    }
    
    private void GenerateMob()
    {
        var randomHuman= RandomGenerator<GameObject>.RandomPicker(humans);
        _newMob = Instantiate(randomHuman, transform.position, rotation);
        _newMob.transform.SetParent(transform);
    }

}
