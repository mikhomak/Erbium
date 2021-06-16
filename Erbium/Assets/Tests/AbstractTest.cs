using System.Collections.Generic;
using General;
using NUnit.Framework;
using Player;
using UnityEngine;

namespace Tests {
    public abstract class AbstractTest {
        protected List<GameObject> gameObjects = new List<GameObject>();
        protected GameObject playerGo;
        protected IPlayer player;

        [SetUp]
        public void SetUpTestScene() {
            gameObjects = Init();

            GameObject inputManagerGo = InitInputManager();
            InputManager inputManager = inputManagerGo.GetComponent<InputManager>();
            playerGo = InitPlayer(inputManager);
            gameObjects.Add(inputManagerGo);
            gameObjects.Add(playerGo);
            player = playerGo.GetComponent<IPlayer>();
        }

        [TearDown]
        public void AfterTest() {
            gameObjects.ForEach(Object.Destroy);
            player = null;
        }


        protected static List<GameObject> Init() {
            List<GameObject> gameObjects = new List<GameObject> {
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Main Camera")),
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Always Forward Camera")),
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Camera Manager")),
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/Enviroments/Test Floor")),
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/General/Timer Manager"))
            };
            return gameObjects;
        }

        protected static GameObject InitInputManager() {
            return Object.Instantiate(Resources.Load<GameObject>("Prefabs/General/Input Manager"));
        }

        protected static GameObject InitPlayer(InputManager inputManager) {
            var playerGo = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"));
            inputManager.playerGameObject = playerGo;
            return playerGo;
        }
    }
}