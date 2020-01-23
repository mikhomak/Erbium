using System.Collections.Generic;
using General;
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
            return gameObjects;
        }

        public static GameObject initInputManager() {
            return Object.Instantiate(Resources.Load<GameObject>("Prefabs/General/Input Manager"));
        }

        public static GameObject initPlayer(InputManager inputManager) {
            var playerGo = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"));
            inputManager.playerGameObject = playerGo;
            return playerGo;
        }
    }
}