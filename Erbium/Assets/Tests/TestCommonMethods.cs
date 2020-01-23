using System.Collections.Generic;
using UnityEngine;

namespace Tests {
    public class TestCommonMethods {


        public static List<GameObject> init() {
            List<GameObject> gameObjects = new List<GameObject> {
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Main Camera")),
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Always Forward Camera")),
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Camera Manager")),
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/Enviroments/Test Floor"))
            };
            var inputManagerGo =
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/General/Input Manager"));
            var playerGo = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"));
            gameObjects.Add(inputManagerGo);
            gameObjects.Add(playerGo);
            return gameObjects;
        } 
        
    }
}