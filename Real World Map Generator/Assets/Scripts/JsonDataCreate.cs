using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class JsonDataCreate : MonoBehaviour
{
    public Map_Co_Ordinates mapList;


    void Awake()
    {
        string mapData = File.ReadAllText(Application.dataPath + "/Resources/Land.json");
        mapList = JsonConvert.DeserializeObject<Map_Co_Ordinates>(mapData);
        Debug.LogWarning(mapList.features.Count);
        Debug.LogWarning(mapList.features[0].geometry.coordinates[0][0][0]);
        Debug.LogWarning(mapList.features[0].geometry.coordinates[0][0][1]);
        foreach (Feature feature in mapList.features)
        {
            Geometry geometry = feature.geometry;
            for (int i = 0; i < geometry.coordinates.Count; i++)
            {
                var corordinatesFirst = geometry.coordinates[i];
                for (int j = 0; j < corordinatesFirst.Count; j++)
                {
                    var corordinatesSecond = corordinatesFirst[j];
                    //Debug.Log(corordinatesFirst.Count + "__" + corordinatesSecond.Count + "_" + corordinatesSecond[0]
                    //    + "," + corordinatesSecond[1]);
                    GameObject gme = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    gme.transform.position = new Vector3((float)corordinatesSecond[0], (float)corordinatesSecond[1], 0.0f);
                    DestroyImmediate(gme.GetComponent<Collider>());
                    gme.transform.parent = transform;
                }
            }
        }
    }


    public class Property
    {
        public string name { get; set; }
    }

    public class Crs
    {
        public string type { get; set; }
        public Property properties { get; set; }
    }

    public class Properties
    {
        public string featurecla { get; set; }
        public int scalerank { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Map_Co_Ordinates
    {
        public string type { get; set; }
        public Crs crs { get; set; }
        public List<Feature> features { get; set; }
    }
}