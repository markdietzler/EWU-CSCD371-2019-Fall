using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace WpfApp1.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel ViewModel { get; set; }

        [TestInitialize]
        public void Setup()
        {
            DateTime now = DateTime.Now;
            ViewModel = new MainWindowViewModel(() => now);
        }

        [TestMethod]
        public void Constructor_SetsDefaultSelectedPerson()
        {
            Assert.AreEqual(ViewModel.People.First(), ViewModel.SelectedPerson);
        }

        [TestMethod]
        public void AddPersonCommand_AddsPerson()
        {
            // Arrange
            int initialCount = ViewModel.People.Count;

            // Act
            ViewModel.AddPersonCommand.Execute(null);

            // Assert
            Assert.AreEqual(initialCount + 1, ViewModel.People.Count);
        }

        [TestMethod]
        public void SelectedPerson_RaisesINPC()
        {
            // Arrange
            ViewModel.PropertyChanged += Vm_PropertyChanged;
            bool eventRaised = false;
            var person = new Person("Foo", "LastName", DateTime.Now);

            // Act
            ViewModel.SelectedPerson = person;

            // Assert
            Assert.IsTrue(eventRaised);
            Assert.AreEqual(person, ViewModel.SelectedPerson);

            void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                Assert.AreEqual(nameof(MainWindowViewModel.SelectedPerson), e.PropertyName);
                eventRaised = true;
            }
        }

    }
}
