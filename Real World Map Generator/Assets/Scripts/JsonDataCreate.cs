using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class JsonDataCreate : MonoBehaviour
{
    public Map_Co_Ordinates mapList;

    void Start()
    {
    }


    void Awake()
    {
        string mapData = File.ReadAllText(Application.dataPath + "/Resources/Land.json");
        mapList = JsonConvert.DeserializeObject<Map_Co_Ordinates>(mapData);
        Debug.LogWarning(mapList.features.Count);
    }


    public class Properties
    {
        public string name { get; set; }
    }

    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties2
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
        public Properties2 properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Map_Co_Ordinates
    {
        public string type { get; set; }
        public Crs crs { get; set; }
        public List<Feature> features { get; set; }
    }
}