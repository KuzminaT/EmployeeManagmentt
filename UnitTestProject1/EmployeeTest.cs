using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeManagment;

namespace UnitTestProject1
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            var name = "Иван Иванов";
            var position = "Разработчик";
            var hireDate = new DateTime(2021, 3, 21);

            var employee = new Employee(name, position, hireDate);

            Assert.AreEqual(name, employee.Name);
            Assert.AreEqual(position, employee.Position);
            Assert.AreEqual(hireDate, employee.HireDate);
            Assert.IsNull(employee.VacationStart);
            Assert.IsNull(employee.VacationEnd);
        }
        [TestMethod]
        public void TestIsOnVacation_AllNull()
        {
            var name = "Иван Иванов";
            var position = "Разработчик";
            var hireDate = new DateTime(2021, 3, 21);

            var employee = new Employee(name, position, hireDate);

            Assert.IsFalse(employee.IsOnVacation);
        }
        [TestMethod]
        public void TestIsOnVacation_VacationStartNull()
        {
            var name = "Иван Иванов";
            var position = "Разработчик";
            var hireDate = new DateTime(2021, 3, 21);

            var employee = new Employee(name, position, hireDate);
            employee.VacationEnd = new DateTime(2026, 4, 15);

            Assert.IsFalse(employee.IsOnVacation);
        }
        [TestMethod]
        public void TestIsOnVacation_VacationEndNull()
        {
            var name = "Иван Иванов";
            var position = "Разработчик";
            var hireDate = new DateTime(2021, 3, 21);

            var employee = new Employee(name, position, hireDate);
            employee.VacationStart = new DateTime(2026, 4, 15);

            Assert.IsFalse(employee.IsOnVacation);

        }
        [TestMethod]
        public void TestIsOnVacation_ReturnFalse()
        {
            var name = "Иван Иванов";
            var position = "Разработчик";
            var hireDate = new DateTime(2021, 3, 21);

            var employee = new Employee(name, position, hireDate);
            employee.VacationStart = new DateTime(2026, 3, 15);
            employee.VacationEnd = new DateTime(2026, 3, 21);

            Assert.IsFalse(employee.IsOnVacation);
        }
        [TestMethod]
        public void TestIsOnVacation_ReturnTrue()
        {
            var name = "Иван Иванов";
            var position = "Разработчик";
            var hireDate = new DateTime(2021, 3, 21);

            var employee = new Employee(name, position, hireDate);
            employee.VacationStart = new DateTime(2026, 4, 21);
            employee.VacationEnd = new DateTime(2026, 5, 5);

            Assert.IsTrue(employee.IsOnVacation);
        }
        [TestMethod]
        public void TestIsOnVacation_ReturnTrue_TodayStart()
        {
            var name = "Иван Иванов";
            var position = "Разработчик";
            var hireDate = new DateTime(2021, 3, 21);

            var employee = new Employee(name, position, hireDate);
            employee.VacationStart = DateTime.Now;
            employee.VacationEnd = new DateTime(2026, 5, 5);

            Assert.IsTrue(employee.IsOnVacation);
        }
        [TestMethod]
        public void TestIsOnVacation_ReturnTrue_TodayEnd()
        {
            var name = "Иван Иванов";
            var position = "Разработчик";
            var hireDate = new DateTime(2021, 3, 21);

            var employee = new Employee(name, position, hireDate);
            employee.VacationStart = new DateTime(2026, 4, 21);
            employee.VacationEnd = DateTime.Now;

            Assert.IsTrue(employee.IsOnVacation);
        }
    }
}
