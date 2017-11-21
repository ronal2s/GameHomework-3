using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour {

    public Dictionary<string, GameObject> SpritesPrefabs;
//    float proporcionTemporal;
//    private SpriteRenderer render;
	public GameObject objeto;
    private void Awake()
    {
        SpritesPrefabs = new Dictionary<string, GameObject>
        {
            //{"1", Resources.Load("jugador1") as GameObject},
            //{"2", Resources.Load("jugador2") as GameObject},
            {"_", Resources.Load("espacio") as GameObject},
            {"@", Resources.Load("BloqueA0") as GameObject}

        };
    }
    // Use this for initialization
    void Start () {
        //Resources.Load<TextAsset>("nivel1");
        TextAsset mapa = Resources.Load<TextAsset>("nivel1");
        CargarMapa(mapa.text);
	}

    void CargarMapa(string mapa)
    {
        
        string[] filasMapa = mapa.Split('\n');
        for (int i = 0; i < filasMapa.Length; i++)
        {
            for (int j = 0; j < filasMapa[i].Length; j++)
            {
                if (filasMapa[i][j] == ' ' || filasMapa[i][j] == '\r')
                    continue;
				
			//	render = SpritesPrefabs[filasMapa[i][j].ToString()].GetComponent<SpriteRenderer>();
//				print ('\t' + filasMapa [i] [j].ToString());
                //Debug.Log(filasMapa[i][j]);
//				proporcionTemporal = render.sprite.rect.width /
//					render.sprite.rect.height;								//*proporcionTemporal
				objeto = Instantiate(SpritesPrefabs[filasMapa[i][j].ToString()], new Vector3(((j*Random.Range(8,8)))- 8.3f,(i * -1) - 4f),Quaternion.identity);
				objeto.transform.localScale = new Vector3 (Random.Range (2.2f, 4), 0.5024082f,1); 
            }
        }
    }





	
	// Update is called once per frame
	void Update () {
		
	}
}
