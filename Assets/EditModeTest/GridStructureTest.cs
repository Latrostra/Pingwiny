using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Tests {
    public class GridStructureTest
    {
        GridStructure structure;
        [OneTimeSetUp]
        public void Init() {
            structure = new GridStructure(3, 100, 100);
        }
        #region CheckCalculatePosition
        [Test]
        public void CalculateGridPositionPasses() {
            Vector3 position = new Vector3(0, 0, 0);
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            Assert.AreEqual(Vector3.zero, returnPosition);
        }

        [Test]
        public void CalculateGridPositionFloatPasses() {
            Vector3 position = new Vector3(2.9f, 0, 2.9f);
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            Assert.AreEqual(Vector3.zero, returnPosition);
        }

        [Test]
        public void CalculateGridPositionFloatSecondPasses() {
            Vector3 position = new Vector3(4.5f, 0, 4.5f);
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            Assert.AreEqual(new Vector3(3f, 0, 3f), returnPosition);
        }

        [Test]
        public void CalculateGridPositionFail() {
            Vector3 position = new Vector3(3.1f, 0, 0);
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            Assert.AreNotEqual(Vector3.zero, returnPosition);
        }
        #endregion
        #region CheckPlaceStructure
        [Test]
        public void PlaceStructureOn606AndCheckIsCellTaken() {
            Vector3 position = new Vector3(6, 0, 6);
            GameObject testGameObject = new GameObject("Test");
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            Assert.IsTrue(structure.IsCellTaken(position));
        }
        [Test]
        public void PlaceStructureOnMinAndCheckIsCellTaken() {
            Vector3 position = new Vector3(0, 0, 0);
            GameObject testGameObject = new GameObject("Test");
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            Assert.IsTrue(structure.IsCellTaken(position));
        }
        [Test]
        public void PlaceStructureOnMaxAndCheckIsCellTaken() {
            Vector3 position = new Vector3(structure.width * 3 - 3, 0, structure.length * 3 - 3);
            GameObject testGameObject = new GameObject("Test");
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            Assert.IsTrue(structure.IsCellTaken(position));
        }
        [Test]
        public void PlaceStructureOnOutOfBoundsAndThrowException() {
            Vector3 position = new Vector3(structure.width * 3 + 100, 0, structure.length * 3 + 100);
            GameObject testGameObject = new GameObject("Test");
            structure.PlaceStructureOnTheGrid(testGameObject, position);
            Assert.Throws<IndexOutOfRangeException>(() => structure.IsCellTaken(position));
        }
        #endregion
    }
}

