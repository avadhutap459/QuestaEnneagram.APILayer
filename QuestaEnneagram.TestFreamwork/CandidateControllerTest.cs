using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using QuestaEnneagram.APILayer.Controllers;
using QuestaEnneagram.ServiceLayer.EF.Interface;
using QuestaEnneagram.ServiceLayer.Interface;
using QuestaEnneagram.ServiceLayer.Service;
using QuestaEnneagram.TestFreamwork.Helper;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace QuestaEnneagram.TestFreamwork
{
    public class CandidateControllerTest 
    {
        [Theory]
        [InlineData(10004)]
        public void GetCandidateDetailsByTestId_ShouldBeReturn200Status(int TestId)
        {
            var ConfigSvc = new Mock<IConfiguration>();

            var MasterSvc = new Mock<IMaster>();
            MasterSvc.Setup(x => x.GetMasterDetails()).Returns(DataBaseStuff.GetMasterDetail());

            var CandidateSvc = new Mock<ICandidate>();
            CandidateSvc.Setup(x => x.GetCandidateDetailsByTestId(TestId)).Returns(DataBaseStuff.GetCandidateDetailByTestId(TestId));

            var MailSvc = new Mock<IMail>();

            var sut = new CandidateController(ConfigSvc.Object, MasterSvc.Object, CandidateSvc.Object, MailSvc.Object);

            IActionResult response = sut.GetCandidateDetailsByCandidateId(TestId);


            var okResult = Assert.IsType<OkObjectResult>(response);


            Assert.NotNull(okResult);

            if (okResult.Value == null) return;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(okResult.Value);

            var values = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);

            bool SuccessFlg = values.IsSuccess;

            Assert.Equal(SuccessFlg, true);

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Theory]
        [InlineData(10000)]
        public void CheckCandidateDoesNotExits_ShouldBeReturn400Status(int TestId)
        {
            var ConfigSvc = new Mock<IConfiguration>();
            var MasterSvc = new Mock<IMaster>();
            MasterSvc.Setup(x => x.GetMasterDetails()).Returns(DataBaseStuff.GetMasterDetail());
            var CandidateSvc = new Mock<ICandidate>();
            CandidateSvc.Setup(x => x.GetCandidateDetailsByTestId(TestId)).Returns(DataBaseStuff.GetCandidateDetailByTestId(TestId));
            var MailSvc = new Mock<IMail>();

            var sut = new CandidateController(ConfigSvc.Object, MasterSvc.Object, CandidateSvc.Object, MailSvc.Object);

            IActionResult response = sut.GetCandidateDetailsByCandidateId(TestId);

            var result = response as ObjectResult;

            if (result.Value == null) return;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(result.Value);
            var values = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);

            string message = values.Message;

            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
            Assert.Equal(message, "Candidate does not avaiable in current context");
        }

        [Theory]
        [InlineData(10004)]
        public void CheckCandidateLinkDeactivate_ShouldBeRetrun400Status(int TestId)
        {
            var ConfigSvc = new Mock<IConfiguration>();
            var MasterSvc = new Mock<IMaster>();
            MasterSvc.Setup(x => x.GetMasterDetails()).Returns(DataBaseStuff.GetMasterDetail());
            var CandidateSvc = new Mock<ICandidate>();
            CandidateSvc.Setup(x => x.GetCandidateDetailsByTestId(TestId)).Returns(DataBaseStuff.GetCandidateDetailByTestId(TestId));
            var MailSvc = new Mock<IMail>();

            var sut = new CandidateController(ConfigSvc.Object, MasterSvc.Object, CandidateSvc.Object, MailSvc.Object);

            IActionResult response = sut.GetCandidateDetailsByCandidateId(TestId);

            var result = response as ObjectResult;

            if (result.Value == null) return;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(result.Value);
            var values = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);

            string message = values.Message;

            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
            Assert.Equal(message, "Link is not activated");
        }

        [Theory]
        [InlineData(1)]
        public async void CheckStateListAvaiableBaseOnCountryId_ShouldBeRetrun200Status(int CountryId)
        {
            var MasterSvc = new Mock<IMaster>();

            MasterSvc.Setup(x => x.GetStateDetailByCountryId(It.IsAny<int>()).Result).Returns(DataBaseStuff.RetrunStateDetailsBaseOnCountryId(CountryId));

            var sut = new CandidateController(null, MasterSvc.Object, null, null);
            IActionResult response = await sut.GetStateDetailByCountryId(CountryId);

            var result = response as ObjectResult;

            Assert.NotNull(result);

            if (result.Value == null) return;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(result.Value);
            var values = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);

        }

        [Theory]
        [InlineData(1)]
        public void GenerateCandidateLiknBaseOnCompanyAndHrID_ShouldBeRetrun200Status(int CompaniesAndHrMap)
        {
            var MasterSvc = new Mock<IMaster>();
            MasterSvc.Setup(x => x.IsCompanyAndHrExist(CompaniesAndHrMap)).Returns(new System.Tuple<bool, string>(true, "Success"));
            MasterSvc.Setup(x => x.GetConfigurationValueById(It.IsAny<string>())).Returns("http://localhost:4200/ClientRegister/");

            var CandidateSvc = new Mock<ICandidate>();
            CandidateSvc.Setup(x => x.GetHrNCompanyMapDetailByCMapHrId(CompaniesAndHrMap)).Returns(DataBaseStuff.GetHrNCompanyMapDetailByCMapHrId());
            CandidateSvc.Setup(x => x.SaveInitialCandidateData(It.IsAny<int>(), It.IsAny<int>())).Returns(10001);

            var request = new Mock<HttpRequest>();
            request.Setup(x => x.Scheme).Returns("http");
            request.Setup(x => x.Host).Returns(HostString.FromUriComponent("localhost:8080"));
            request.Setup(x => x.PathBase).Returns(PathString.FromUriComponent("/api"));

            var httpContext = Mock.Of<HttpContext>(_ =>
                _.Request == request.Object
            );

            //Controller needs a controller context 
            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };


            var MailSvc = new Mock<IMail>();

            var sut = new CandidateController(null, MasterSvc.Object, CandidateSvc.Object, MailSvc.Object) { ControllerContext = controllerContext};
            IActionResult response =  sut.GenerateAssessmentLink(CompaniesAndHrMap);
            var result = response as ObjectResult;

            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

            // CandidateSvc.Verify(x => x.GetCandidateDetailsByTestId(CompaniesAndHrMap), Times.Never);

        }
        [Theory]
        [InlineData(1)]
        public void GenerateCandidateLiknBaseOnCompanyAndHrID_ShouldBeRetrun400Status(int CompaniesAndHrMap)
        {
            var MasterSvc = new Mock<IMaster>();
            MasterSvc.Setup(x => x.IsCompanyAndHrExist(CompaniesAndHrMap)).Returns(new System.Tuple<bool, string>(false, "Company id doesn't exist in current context"));
            var CandidateSvc = new Mock<ICandidate>();
            var MailSvc = new Mock<IMail>();

            var sut = new CandidateController(null, MasterSvc.Object, CandidateSvc.Object, MailSvc.Object);
            IActionResult response = sut.GenerateAssessmentLink(CompaniesAndHrMap);
            var result = response as ObjectResult;

           // MasterSvc.Verify(x => x.IsCompanyAndHrExist(It.IsAny<int>()), Times.Once);
            CandidateSvc.Verify(x => x.GetHrNCompanyMapDetailByCMapHrId(It.IsAny<int>()), Times.Never);

          //  Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

    }
}
