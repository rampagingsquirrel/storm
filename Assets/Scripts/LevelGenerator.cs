using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;


public class LevelGenerator : MonoBehaviour
{
    public int minX = -150000;
    public int minZ = -150000;
    public int maxX = 150000;
    public int maxZ = 150000;
    public float planetY = -5;
    public float nebulaY = -10;
    public float asteroidY = 0;
    public int minSSDistance = 100;
    public int maxSSDistance = 200;
        
    public float maxSolarSystems = 500;
    public int minPlanets = 3;
    public int maxPlanets = 6;

    // index of space objects
    List<SpaceObject> stars = new List<SpaceObject>();
    List<SpaceObject> planets = new List<SpaceObject>();

    public GameObject planetPrefab;
    public GameObject nebulaPrefab;
    public GameObject starPrefab;
        
    
	// Use this for initialization
	void Start ()
    {
        // check to see if map file exists
        if (!File.Exists("universe.xml"))
        {
            GenerateUniverse();
            SpawnStars();
            SpawnPlanets();
        }

        else
        {
            LoadUniverse();
            SpawnStars();
            SpawnPlanets();
        }
                       
                
	}

    void LoadUniverse()
    {
        XmlReader reader = XmlReader.Create("universe.xml");

        while (reader.Read())
        {
            if (reader.IsStartElement())
            {
                
                switch (reader.Name)
                {
                    case "star":
                        Star star = new Star();
                        reader.ReadToFollowing("coordX");
                        star.position.x = reader.ReadElementContentAsFloat();

                        //reader.ReadToFollowing("coordZ");
                        star.position.z = reader.ReadElementContentAsFloat();

                        stars.Add(star);
                        Debug.Log("star added");
                        break;

                    case "planet":
                        Planet planet = new Planet();
                        reader.ReadToFollowing("coordX");
                        planet.position.x = reader.ReadElementContentAsFloat();

                        //reader.ReadToFollowing("coordZ");                      
                        planet.position.z = reader.ReadElementContentAsFloat();
                        

                        planets.Add(planet);
                        Debug.Log("planet added");
                        break;                                       
                        
                }
            }
        }
    }

    void WriteMapFile()
    {
        using (XmlWriter writer = XmlWriter.Create("universe.xml"))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("universe");

            // write stars to file
            writer.WriteStartElement("stars");

            foreach (Star star in stars)
            {
                writer.WriteStartElement("star");
                writer.WriteElementString("coordX", star.position.x.ToString());
                writer.WriteElementString("coordZ", star.position.z.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            // write planets to file
            
            writer.WriteStartElement("planets");

            foreach (Planet planet in planets)
            {
                writer.WriteStartElement("planet");
                writer.WriteElementString("coordX", planet.position.x.ToString());
                writer.WriteElementString("coordZ", planet.position.z.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            
        }
    }
    
    void GenerateUniverse()
    {        
        Debug.Log("Generating Solar System");
        for (int i = 0; i <= maxSolarSystems; i++)
        {
            Vector3 pos = new Vector3(Random.Range(minX, maxX), planetY, Random.Range(minZ, maxX));
            // Create star and provide attributes
            Star star = new Star();
            star.position = pos;

            // Register star
            stars.Add(star);
           

            // Determine how many planets are in the system and their location relative to the star
            float numPlanets = Random.Range(minPlanets, maxPlanets);
            for (int p = 0; p <= numPlanets; p++)
            {
                //Vector3 planetPos = new Vector3(Random.Range((pos.x + minSSDistance), (pos.x + maxSSDistance)), planetY, Random.Range((pos.z + minSSDistance), (pos.z + maxSSDistance)));
                                
                float distance = Random.Range(minSSDistance, maxSSDistance);
                
                    
                float angle = Random.Range(0f, 360f * Mathf.Deg2Rad);
                Vector2 delta = new Vector2(Mathf.Cos(angle) * distance, Mathf.Sin(angle) * distance);

                Debug.Log(distance);

                // Create planet and provide attributes
                Planet planet = new Planet();
                planet.position.x = pos.x + delta.x;
                planet.position.z = pos.z + delta.y;

                //Register planet
                planets.Add(planet);
                
            }

        }

        WriteMapFile();
                
        Debug.Log("Done.");

    }

    void SpawnStars()
    {
        Debug.Log("Spawning stars...");

        foreach (Star star in stars)
        {
            //GameObject spawnedObject = GameObject.Instantiate(planetPrefab, star.position, Quaternion.identity) as GameObject;
            Instantiate(starPrefab, star.position, Quaternion.identity);
        }

    }

    void SpawnPlanets()
    {
        Debug.Log("Spawning planets...");

        foreach (Planet planet in planets)
        {
            //GameObject spawnedObject = GameObject.Instantiate(planetPrefab, planet.position, Quaternion.identity) as GameObject;
            Instantiate(planetPrefab, planet.position, Quaternion.identity);
        }
    }
	    
       
    
}
