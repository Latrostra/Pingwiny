using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Tests {
    public class CellTest
    {
        [Test]
        public void CellSetConstructionPasses() {
            Cell cell = new Cell();
            cell.SetConstruction(new GameObject("test"));
            Assert.IsTrue(cell.IsTaken);
        }
        [Test]
        public void CellSetNullConstructionPasses() {
            Cell cell = new Cell();
            cell.SetConstruction(null);
            Assert.IsFalse(cell.IsTaken);
        }
    }
}

