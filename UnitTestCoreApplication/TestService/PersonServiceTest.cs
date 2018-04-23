using Moq;
using Moq.Protected;
using CoreApplication.Repository;
using CoreApplication.Entity;
using CoreApplication.Controller;
using System.Collections.Generic;
using CoreApplication.Service;
using CoreApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCoreApplication.TestService
{
    [TestClass]
    public class PersonServiceTest
    {
        IList<Person> persons;
        public void Setup()
        {

        }
        [TestMethod]
        public void GetPetOwnersByPetCat_Test()
        {
            //Moq Repp
            var mockRepository = new Mock<IRepository>();

            //Setup - Data Provider
            IPersonService testObject = new PersonService(mockRepository.Object);

            //Setup - Data from webservice
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
            mockRepository.Setup(service => service.GetAll()).Returns(persons);

            //Test
            var actualResult = testObject.GetPetOwnersByPetCat();

            //Expected result
            IList<string> expectedResult = new List<string> { "Bob","Jennifer", "Fred","Samantha" , "Alice" };
            //Test result
            Assert.AreEqual(5, actualResult.Count);
            Assert.AreEqual(expectedResult[0], actualResult[0].Name);
            Assert.AreEqual(expectedResult[1], actualResult[1].Name);
            Assert.AreEqual(expectedResult[2], actualResult[2].Name);
            Assert.AreEqual(expectedResult[3], actualResult[3].Name);
            Assert.AreEqual(expectedResult[4], actualResult[4].Name);
            //Verify Mock
            mockRepository.Verify(m => m.GetAll());
        }

        [TestMethod]
        public void GetPetOwnersByPetCat_OwnersWithNoPetCat()
        {
            //Moq Repp
            var mockRepository = new Mock<IRepository>();

            //Setup - Data Provider
            IPersonService testObject = new PersonService(mockRepository.Object);

            //Setup - Data from webservice
            var ownersWithNoPetCat = new List<Person>()
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
                             Type = PetTypeEnum.Fish
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
                             Type = PetTypeEnum.Fish
                         },
                          new Pet()
                         {
                             Name = "Max",
                             Type = PetTypeEnum.Fish
                         },
                          new Pet()
                         {
                             Name = "Sam",
                             Type = PetTypeEnum.Dog
                         },
                          new Pet()
                         {
                             Name = "Jim",
                             Type = PetTypeEnum.Fish
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
                             Type = PetTypeEnum.Fish
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
                             Type = PetTypeEnum.Fish
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
                             Type = PetTypeEnum.Fish
                         }
                     }
                },
            };
            mockRepository.Setup(service => service.GetAll()).Returns(ownersWithNoPetCat);

            //Test
            var actualResult = testObject.GetPetOwnersByPetCat();

           
            //Test result
            Assert.AreEqual(0, actualResult.Count);

            //Verify Mock
            mockRepository.Verify(m => m.GetAll());
        }

        [TestMethod]
        public void GetPetOwnersByPetCat_OwnersWithNoPet()
        {
            //Moq Repp
            var mockRepository = new Mock<IRepository>();

            //Setup - Data Provider
            IPersonService testObject = new PersonService(mockRepository.Object);

            //Setup - Data from webservice
            var ownersWithNoPet = new List<Person>()
            {
                new Person()
                {
                     Name = "Bob",
                     Gender = GenderEnum.Male,
                     Age = 23,
                     Pets = null
                },

                new Person()
                {
                     Name = "Tom",
                     Gender = GenderEnum.Male,
                     Age = 23,
                     Pets = null
                },
            };
            mockRepository.Setup(service => service.GetAll()).Returns(ownersWithNoPet);

            //Test
            var actualResult = testObject.GetPetOwnersByPetCat();


            //Test result
            Assert.AreEqual(0, actualResult.Count);

            //Verify Mock
            mockRepository.Verify(m => m.GetAll());
        }

        [TestMethod]
        [ExpectedException(typeof(AppException))]
        public void GetPetOwnersByPetCat_AppException()
        {
            //Moq Repp
            var mockRepository = new Mock<IRepository>();

            //Setup - Data Provider
            IPersonService testObject = new PersonService(mockRepository.Object);

            //Setup - Data from webservice
            var ownersWithNoPet = new List<Person>()
            {
                new Person()
                {
                     Name = "Bob",
                     Gender = GenderEnum.Male,
                     Age = 23,
                     Pets = null
                },

                new Person()
                {
                     Name = "Tom",
                     Gender = GenderEnum.Male,
                     Age = 23,
                     Pets = null
                },
            };
            mockRepository.Setup(service => service.GetAll()).Throws(new AppException(message: "Service not available."));
            //Test
            var actualResult = testObject.GetPetOwnersByPetCat();

        }
        [TestMethod]
        public void GetPetOwnersByPetCat_NullOwnersList()
        {
            //Moq Repp
            var mockRepository = new Mock<IRepository>();

            //Setup - Data Provider
            IPersonService testObject = new PersonService(mockRepository.Object);

            //Setup - Data from webservice
            IList<Person> ownersWithNoPet = null;
            mockRepository.Setup(service => service.GetAll()).Returns(ownersWithNoPet);

            //Test
            var actualResult = testObject.GetPetOwnersByPetCat();


            //Test result
            Assert.AreEqual(null, actualResult);

            //Verify Mock
            mockRepository.Verify(m => m.GetAll());
        }
    }
}
