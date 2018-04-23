using Moq;
using Moq.Protected;
using NUnit.Framework;
using CoreApplication.Repository;
using CoreApplication.Entity;
using CoreApplication.Controller;
using System.Collections.Generic;
using CoreApplication.Service;
using CoreApplication;


namespace TestCoreApplication
{
    [TestFixture]
    public class PersonControllerTest
    {
        IList<Person> persons;

        [TestInitialize]
        public void Init()
        {
            //Test data
            persons = new List<Person>()
            {
                new Person()
                {
                     Name = "Bob",
                     Gender = GenderEnum.Male,
                     Age = 23,
                     Pets = new List<Pet>()
                     {
                         new Pet()
                         {
                             Name = "Garfield",
                             Type = PetTypeEnum.Cat
                         },
                          new Pet()
                         {
                             Name = "Fido",
                             Type = PetTypeEnum.Dog
                         }
                     }


                },

                new Person()
                {
                     Name = "Jennifer",
                     Gender = GenderEnum.Female,
                     Age = 18,
                     Pets = new List<Pet>()
                     {
                         new Pet()
                         {
                             Name = "Garfield",
                             Type = PetTypeEnum.Cat
                         }
                     }
                },

                new Person()
                {
                     Name = "Steve",
                     Gender = GenderEnum.Male,
                     Age = 45,
                     Pets = null
                },

                new Person()
                {
                     Name = "Fred",
                     Gender = GenderEnum.Male,
                     Age = 40,
                     Pets = new List<Pet>()
                     {
                         new Pet()
                         {
                             Name = "Tom",
                             Type = PetTypeEnum.Cat
                         },
                          new Pet()
                         {
                             Name = "Max",
                             Type = PetTypeEnum.Cat
                         },
                          new Pet()
                         {
                             Name = "Sam",
                             Type = PetTypeEnum.Dog
                         },
                          new Pet()
                         {
                             Name = "Jim",
                             Type = PetTypeEnum.Cat
                         },
                     }
                },
                new Person()
                {
                     Name = "Samantha",
                     Gender = GenderEnum.Female,
                     Age = 40,
                     Pets = new List<Pet>()
                     {
                         new Pet()
                         {
                             Name = "Tabby",
                             Type = PetTypeEnum.Cat
                         }
                     }
                },
                new Person()
                {
                     Name = "Alice",
                     Gender = GenderEnum.Female,
                     Age = 64,
                     Pets = new List<Pet>()
                     {
                         new Pet()
                         {
                             Name = "Simba",
                             Type = PetTypeEnum.Cat
                         },
                         new Pet()
                         {
                             Name = "Nemo",
                             Type = PetTypeEnum.Fish
                         }
                     }
                },
            };
        }
        [Test]
        public void GetPetOwnerNamesByPetCat_Test()
        {
            //Moq Service Layer
            var mockRepository = new Mock<IRepository>();

            var mockServiceProvider = new Mock<IPersonService>();

            //Setup - Data Provider
            var testObject = new Mock<PersonController>(mockRepository.Object);
       
            //Setup - Service Provider
            testObject.Protected().SetupGet<IPersonService>("ServiceProvider").Returns(mockServiceProvider.Object);
            var sortedPersons = new List<Person>()
            {
                new Person()
                {
                     Name = "Bob",
                     Gender = GenderEnum.Male,
                     Age = 23,
                     Pets = new List<Pet>()
                     {
                         new Pet()
                         {
                             Name = "Garfield",
                             Type = PetTypeEnum.Cat
                         },
                          new Pet()
                         {
                             Name = "Fido",
                             Type = PetTypeEnum.Dog
                         }
                     }


                },

                new Person()
                {
                     Name = "Fred",
                     Gender = GenderEnum.Male,
                     Age = 40,
                     Pets = new List<Pet>()
                     {
                         new Pet()
                         {
                             Name = "Tom",
                             Type = PetTypeEnum.Cat
                         },
                          new Pet()
                         {
                             Name = "Max",
                             Type = PetTypeEnum.Cat
                         },
                          new Pet()
                         {
                             Name = "Sam",
                             Type = PetTypeEnum.Dog
                         },
                          new Pet()
                         {
                             Name = "Jim",
                             Type = PetTypeEnum.Cat
                         },
                     }
                },

                new Person()
                {
                     Name = "Alice",
                     Gender = GenderEnum.Female,
                     Age = 64,
                     Pets = new List<Pet>()
                     {
                         new Pet()
                         {
                             Name = "Simba",
                             Type = PetTypeEnum.Cat
                         },
                         new Pet()
                         {
                             Name = "Nemo",
                             Type = PetTypeEnum.Fish
                         }
                     }
                },
                new Person()
                {
                     Name = "Jennifer",
                     Gender = GenderEnum.Female,
                     Age = 18,
                     Pets = new List<Pet>()
                     {
                         new Pet()
                         {
                             Name = "Garfield",
                             Type = PetTypeEnum.Cat
                         }
                     }
                },
                 new Person()
                {
                     Name = "Samantha",
                     Gender = GenderEnum.Female,
                     Age = 40,
                     Pets = new List<Pet>()
                     {
                         new Pet()
                         {
                             Name = "Tabby",
                             Type = PetTypeEnum.Cat
                         }
                     }
                },
            };
            //Setup - Data
            mockServiceProvider.Setup(service => service.GetPetOwnersByPetCat()).Returns(persons);

            //Call Method
           var actualResult = testObject.Object.GetPetOwnerNamesByPetCat();
            //Expected result
            IList<string> expectedResult = new List<string> { "Alice", "Jennifer", "Samantha" ,"Bob", "Fred" };
            //Test result
            Assert.AreEqual(actualResult.FemaleOwners.Count, 3);
            Assert.AreEqual(actualResult.MaleOwners.Count, 2);
            Assert.AreEqual(actualResult.FemaleOwners[0], expectedResult[0]);
            Assert.AreEqual(actualResult.FemaleOwners[1], expectedResult[1]);
            Assert.AreEqual(actualResult.FemaleOwners[2], expectedResult[2]);
            Assert.AreEqual(actualResult.MaleOwners[0], expectedResult[3]);
            Assert.AreEqual(actualResult.MaleOwners[1], expectedResult[4]);

        }
        [Test]
        public void GetPetOwnerNamesByPetCat_TestForNoOwners()
        {
            //Moq Service Layer
            var mockRepository = new Mock<IRepository>();

            var mockServiceProvider = new Mock<IPersonService>();

            //Setup - Data Provider
            var testObject = new Mock<PersonController>(mockRepository.Object);

            //Setup - Service Provider
            testObject.Protected().SetupGet<IPersonService>("ServiceProvider").Returns(mockServiceProvider.Object);
            //Setup - Data
            mockServiceProvider.Setup(service => service.GetPetOwnersByPetCat()).Returns((IList<Person>)null);

            //Call Method
            var actualResult = testObject.Object.GetPetOwnerNamesByPetCat();
            //Expected result

            //Test Result
            Assert.AreSame(actualResult, null);

        }

        [Test]
        [ExpectedException(typeof(AppException), ExpectedMessage = "Access Denied - Invalid user name and/or password.")]
        public void GetPetOwnerNamesByPetCat_ThrowAppException()
        {
            //Moq Service Layer
            var mockRepository = new Mock<IRepository>();

            var mockServiceProvider = new Mock<IPersonService>();

            //Setup - Data Provider
            var testObject = new Mock<PersonController>(mockRepository.Object);
            //Setup - Service Provider
            testObject.Protected().SetupGet<IPersonService>("ServiceProvider").Returns(mockServiceProvider.Object);
            //Setup - Data
            mockServiceProvider.Setup(service => service.GetPetOwnersByPetCat()).Throws(new AppException(message: "Service not available."));

            //Call Method
            var actualResult = testObject.Object.GetPetOwnerNamesByPetCat();
            //Expected result

            //Test Result
            Assert.AreSame(actualResult, null);

        }

        [TestMethod]
        [ExpectedException(typeof(AppException), ExpectedMessage ="")]
        public void GetPetOwnerNamesByPetCat_ThrowAppException_RepoNotset()
        {
            //Moq Service Layer
            var mockRepository = new Mock<IRepository>();

            IPersonService mockServiceProvider = null;

            //Setup - Data Provider
            var testObject = new Mock<PersonController>(mockRepository.Object);

            //Setup - Service Provider
            testObject.Protected().SetupGet<IPersonService>("ServiceProvider").Returns(mockServiceProvider);

            //Call Method
            var actualResult = testObject.Object.GetPetOwnerNamesByPetCat();
            //Expected result

            //Test Result
            Assert.AreSame(actualResult, null);

        }

    }
}
