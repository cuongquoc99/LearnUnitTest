using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using WebApplication1.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class ExpenditureControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new ExpendituresEntities();
            var controller = new ExpenditureController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as List<Expenditure>;
            Assert.IsInstanceOfType(result.Model, typeof(List<Expenditure>));
            Assert.AreEqual(db.Expenditures.Count(), (result.Model as List<Expenditure>).Count);


        }

        public void TestCreateG()
        {
            var controller = new ExpenditureController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        public void TestEditG()
        {
            var controller = new ExpenditureController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            var db = new ExpendituresEntities();
            var item = db.Expenditures.First();
            var result1 = controller.Edit(item.ID) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as Expenditure;
            Assert.AreEqual(item.ID, model.ID);
        }
    }
}