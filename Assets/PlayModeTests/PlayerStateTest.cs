using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Test
{
    
    [TestFixture]
    public class PlayerStateTest
    {
        UiController uiController;
        InputManager inputManagerComponent;
        GameManager gameManager;

        [SetUp]
        public void Init() {
            GameObject gameManagerObject = new GameObject();
            var cameraMovement = gameManagerObject.AddComponent<CameraMovement>();
            inputManagerComponent = gameManagerObject.AddComponent<InputManager>();
            uiController = gameManagerObject.AddComponent<UiController>();
            GameObject buttonBuildObject = new GameObject();
            GameObject buttonCancelObject = new GameObject();
            GameObject cancelPanel = new GameObject();
            GameObject demolishButton = new GameObject();
            uiController.cancelButton = buttonCancelObject.AddComponent<Button>();
            var buttonBuildComponent = buttonBuildObject.AddComponent<Button>();
            uiController.buildButton = buttonBuildComponent;
            uiController.cancelButtonPanel = buttonCancelObject;
            uiController.destroyButton = demolishButton.AddComponent<Button>();
            gameManager = gameManagerObject.AddComponent<GameManager>();
            gameManager.inputManager = inputManagerComponent;
            gameManager.cameraMovement = cameraMovement;
            gameManager.uiController = uiController;
        }

        [UnityTest]
        public IEnumerator PlayerBuildingSelectionStateWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            uiController.buildButton.onClick.Invoke();
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(gameManager.State is PlayerBuildingSelectionState);
        }

        [UnityTest]
        public IEnumerator PlayerDestroyStateWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            uiController.destroyButton.onClick.Invoke();
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(gameManager.State is PlayerDemolishState);
        }

        [UnityTest]
        public IEnumerator PlayerSelectionStateWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(gameManager.State is PlayerSelectionState);
        }
    }
}
