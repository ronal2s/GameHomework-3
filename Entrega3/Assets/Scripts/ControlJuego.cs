using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour {

	public Dictionary<string, GameObject> SpritesPrefabs,SpritesPrefabs2;
//    float proporcionTemporal;
//    private SpriteRenderer render;
	public GameObject objeto;
    private void Awake()
    {
        SpritesPrefabs = new Dictionary<string, GameObject>
        {
            {"@", Resources.Load("BloqueA0") as GameObject}

        };

		SpritesPrefabs2 = new Dictionary<string, GameObject>
		{
			{"#", Resources.Load("Item") as GameObject}

		};
    }
    // Use this for initialization
    void Start () {
        //Resources.Load<TextAsset>("nivel1");
        TextAsset mapa = Resources.Load<TextAsset>("nivel1");
        CargarMapa(mapa.text);
		mapa = Resources.Load<TextAsset> ("items");
		CargarMapa2 (mapa.text);
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
					objeto = Instantiate (SpritesPrefabs [filasMapa [i] [j].ToString ()], new Vector3 (((j * Random.Range (5.5f, 7.5f))) - 8.3f, (i * -1) - 4.5f), Quaternion.identity);
					objeto.transform.localScale = new Vector3 (Random.Range (2.2f, 4), 0.5024082f, 1); 

            }
        }
    }
	void CargarMapa2(string mapa)
	{

		string[] filasMapa = mapa.Split('\n');
		for (int i = 0; i < filasMapa.Length; i++)
		{
			for (int j = 0; j < filasMapa[i].Length; j++)
			{
				if (filasMapa[i][j] == ' ' || filasMapa[i][j] == '\r')
					continue;
					
				Instantiate (SpritesPrefabs2 [filasMapa [i] [j].ToString ()], new Vector3 (j * Random.Range (2, 4) - 8.3f, (i * -1) - 4.5f), Quaternion.identity);

			}
		}
	}




	
	// Update is called once per frame
	void Update () {
		
	}
}
