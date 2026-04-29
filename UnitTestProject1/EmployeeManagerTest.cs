using EmployeeManagment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class EmployeeManagerTest
    {
        [TestInitialize]
        public void Setup()
        {
            string filePath = "employees.txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        [TestMethod]
        public void TestAddEmployee()
        {
            var manager = new EmployeeManager();
            var employee = new Employee("Иван Иванович", "Разработчик", new DateTime(2021, 3, 21));

            manager.AddEmployee(employee);

            Assert.AreEqual(1, manager.Employees.Count);
        }
        [TestMethod]
        public void TestAddEmployee_Negativ()
        {
            var manager = new EmployeeManager();

            Assert.ThrowsException<ArgumentNullException>(() => manager.AddEmployee(null));
        }
        [TestMethod]
        public void TestRemoveEmployee()
        {
            var manager = new EmployeeManager();
            var employee = new Employee("Иван Иванович", "Разработчик", new DateTime(2021, 3, 21));

            manager.RemoveEmployee(employee);

            Assert.AreEqual(0, manager.Employees.Count);
        }
        [TestMethod]
        public void TestRemoveEmployee_Negativ()
        {
            var manager = new EmployeeManager();

            Assert.ThrowsException<ArgumentNullException>(() => manager.AddEmployee(null));
        }
        [TestMethod]
        public void TestUpdateVacation()
        {
            var manager = new EmployeeManager();
            var employee = new Employee("Иван Иванович", "Разработчик", new DateTime(2021, 3, 21));
            employee.VacationStart = new DateTime(2024, 10, 1);
            employee.VacationEnd = new DateTime(2026, 10, 15);
            manager.AddEmployee(employee);

            DateTime start = new DateTime(2026, 4, 1);
            DateTime end = new DateTime(2026, 4, 30);
            manager.UpdateVacation(employee, start, end);

            Assert.AreEqual(start, employee.VacationStart);
            Assert.AreEqual(end, employee.VacationEnd);
        }
        [TestMethod]
        public void TestUpdateVacation_Negativ()
        {
            var manager = new EmployeeManager();

            Assert.ThrowsException<ArgumentNullException>(() => manager.AddEmployee(null));
        }
        [TestMethod]
        public void TestLoadEmployees()
        {
            var manager = new EmployeeManager();
            var employee = new Employee("Иван Иванович", "Разработчик", new DateTime(2021, 3, 21));

            
            DateTime start = new DateTime(2026, 10, 1);
            DateTime end = new DateTime(2026, 10, 15);
            employee.VacationStart = start;
            employee.VacationEnd = end;
            manager.AddEmployee(employee);

            var manager1 = new EmployeeManager();
            var employee1 = manager1.Employees[0];

            Assert.AreEqual("Иван Иванович", employee1.Name);
            Assert.AreEqual("Разработчик", employee1.Position);
            Assert.AreEqual(new DateTime(2021, 3, 21), employee1.HireDate);
            Assert.AreEqual(new DateTime(2026, 10, 1), employee1.VacationStart);
            Assert.AreEqual(new DateTime(2026, 10, 15), employee1.VacationEnd);
        }
    }
}
