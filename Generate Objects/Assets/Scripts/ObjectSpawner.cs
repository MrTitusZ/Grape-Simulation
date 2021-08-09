using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] tokek;
    [SerializeField] GameObject oszlop;

    [Header("T�ke Be�ll�t�sok")]
    [SerializeField] int tokekSzama = 10;
    [SerializeField] float tokekKozottiTavolsag = 2f;
    [SerializeField] float tokekKozottiRandomTavolsag = 0.5f;
    [SerializeField] float tokeRandomRotationFokban = 10f;
    [SerializeField] int tokeSorokSzama = 5;
    [SerializeField] float tokeSorokKozottiTavolsag = 2f;
    
    [Header("Oszlop Be�ll�t�sok")]
    [SerializeField] int oszlopokSzama = 5;
    [SerializeField] float oszlopokK�z�ttiTavolsag = 6f;
    [SerializeField] int oszlopSorokSzama = 5;
    [SerializeField] float oszlopSorokKozottiTavolsag = 2;

    [Header("Dr�tmez� Be�ll�t�sok")]
    [SerializeField] Color drotSzin = new Color(1, 1, 1, 255);

    // List�ban elt�rolom a fut�skor p�ld�nyos�tott oszlopokat GameObject-k�nt
    List<GameObject> oszlopok = new List<GameObject>();
    int randomTokeModell;
    float randomTokeTavolsag;
    float randomTokeRotation;
    float xPos;
    float yPos;
    float zPos;

    void Start()
    {
        SzolomezoGeneralas();
    }

    void SzolomezoGeneralas()
    {
        // T�k�k p�ld�nyos�t�sa
        TokeGeneralas();

        // Oszlopok p�ld�nyos�t�sa
        OszlopGeneralas();

        // Dr�tmez� kialak�t�sa a p�ld�nyos�tott oszlopokhoz
        DrotGeneralas();
    }

    private void TokeGeneralas()
    {
        for (int sorCounter = 0; sorCounter < tokeSorokSzama; sorCounter++)
        {
            for (int tokeCounter = 0; tokeCounter < tokekSzama; tokeCounter++)
            {
                randomTokeModell = Random.Range(0, tokek.Length);
                randomTokeTavolsag = Random.Range(-tokekKozottiRandomTavolsag, tokekKozottiRandomTavolsag);
                randomTokeRotation = Random.Range(-tokeRandomRotationFokban, tokeRandomRotationFokban);
                xPos = transform.position.x + sorCounter * tokeSorokKozottiTavolsag;
                zPos = transform.position.z + 0.5f + tokeCounter * tokekKozottiTavolsag + randomTokeTavolsag;
                yPos = Terrain.activeTerrain.SampleHeight(new Vector3(xPos, 0, zPos));
                Vector3 tokePosition = new Vector3(xPos, yPos, zPos);
                Instantiate(tokek[randomTokeModell], tokePosition, Quaternion.Euler(0, randomTokeRotation, 0));
            }
        }
    }

    private void OszlopGeneralas()
    {
        for (int sorCounter = 0; sorCounter < oszlopSorokSzama; sorCounter++)
        {
            for (int oszlopCounter = 0; oszlopCounter < oszlopokSzama; oszlopCounter++)
            {
                xPos = transform.position.x + sorCounter * oszlopSorokKozottiTavolsag;
                zPos = transform.position.z + oszlopCounter * oszlopokK�z�ttiTavolsag;
                yPos = Terrain.activeTerrain.SampleHeight(new Vector3(xPos, 0, zPos));
                Vector3 oszlopPosition = new Vector3(xPos, yPos, zPos);
                oszlopok.Add(Instantiate(oszlop, oszlopPosition, Quaternion.Euler(-90, 0, 0)) as GameObject);
            }
        }
    }

    private void DrotGeneralas()
    {
        for (int sorCounter = 0; sorCounter < oszlopSorokSzama; sorCounter++)
        {
            for (int pointCounter = 0; pointCounter < 3; pointCounter++)
            {
                GameObject lineRendererGameObject = new GameObject();
                lineRendererGameObject.AddComponent<LineRenderer>();
                LineRenderer lineRenderer = lineRendererGameObject.GetComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.widthMultiplier = 0.01f;
                lineRenderer.positionCount = oszlopokSzama;
                lineRenderer.startColor = drotSzin;
                lineRenderer.endColor = drotSzin;
                for (int oszlopCounter = 0; oszlopCounter < oszlopokSzama; oszlopCounter++)
                {
                    lineRenderer.SetPosition(oszlopCounter, oszlopok[sorCounter * oszlopokSzama + oszlopCounter].transform.GetChild(pointCounter).position);
                }
            }
        }
    }
}