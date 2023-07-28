using Moq;
using QuestaEnneagram.APILayer.Controllers;
using QuestaEnneagram.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuestaEnneagram.TestFreamwork
{
    public class MyClassTests
    {
        [Fact]
        public void LogsSomething()
        {
            //arrange
            var logger = new Mock<ILogger>();

            //act
            var sut = new MyClassController(logger.Object);
            sut.MyMethod();

            //Assert 
            logger.Verify(foo => foo.Log(), Times.Once()); //here
                                                           //some other assertions
        }
    }
}
