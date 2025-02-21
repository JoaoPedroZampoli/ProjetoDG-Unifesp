using UnityEngine;

public class MusgoController : MonoBehaviour
{

    public GameObject fogoMusgo;
    public Transform localDisparo;
    public float tempoMaxEntreDisparos;
    public float tempoAtualDisparos;

    public DetectionController _detectionArea;
    public HeartSystem heart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AtirarFogo();
    }

    private void AtirarFogo()
    {
        tempoAtualDisparos -= Time.deltaTime;
        if(tempoAtualDisparos <= 0)
        {
            Instantiate(fogoMusgo, localDisparo.position, Quaternion.Euler(0f, 0f, 0f));
            tempoAtualDisparos = tempoMaxEntreDisparos;
        }
    }
}
