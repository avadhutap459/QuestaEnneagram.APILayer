using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace QuestaEnneagram.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private IConfiguration _configuration { get; set; }

        public readonly IMaster _mastersvc;
        public readonly ICandidate _candidatesvc;
        public readonly IMail _mailsvc;
        public CandidateController(IConfiguration configuration, IMaster masterService, ICandidate CandidateService, IMail MailService)
        {
            _configuration = configuration;
            _mastersvc = masterService;
            _candidatesvc = CandidateService;
            _mailsvc = MailService;
        }

        [HttpGet("GetMasterDetails")]
        public IActionResult GetMasterDetails()
        {
            var _ = this._mastersvc.GetMasterDetails();

            return Ok();
        }

        [HttpGet("GetCandidateDetailsByTestId")]
        public IActionResult GetCandidateDetailsByCandidateId(int TestId)
        {
            try
            {
                #region  Get Master Details

                MasterBM ObjMasterModel = _mastersvc.GetMasterDetails();

                #endregion

                #region Get Candidate Details

                CandidateBM ObjCandidateModel = _candidatesvc.GetCandidateDetailsByTestId(TestId);

                #endregion

                if(ObjCandidateModel == null)
                {
                    return NotFound(new { IsSuccess = false, Message = "Candidate does not avaiable in current context" });
                }

                if(!ObjCandidateModel.IsActive.Value)
                {
                    return NotFound(new { IsSuccess = false, Message = "Link is not activated" });
                }

                ObjCandidateModel.Industry = _mastersvc.GetIndustryDataByCandidateId(ObjCandidateModel.CandidateId);

                bool DisableAllControls = (ObjCandidateModel.GenderId == 0 || ObjCandidateModel.GenderId is null) ? true : false;


                return Ok(new { IsSuccess = true, IsDisableAllControl = DisableAllControls, CandidateData = ObjCandidateModel });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetState/{CountryId}")]
        public async Task<IActionResult> GetStateDetailByCountryId(int CountryId)
        {
            try
            {
                IList<StateBM> StateList = _mastersvc.GetStateDetailByCountryId(CountryId).Result;

                return Ok(new { StateObject = StateList });
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GenerateAssessment/{CompanyMapToHrId}")]
        public IActionResult GenerateAssessmentLink(int CompanyMapToHrId)
        {
            try
            {
                var _checkCompanyNHrExists = _mastersvc.IsCompanyAndHrExist(CompanyMapToHrId);

                if(!_checkCompanyNHrExists.Item1)
                {
                    return NotFound(new { _checkCompanyNHrExists.Item2 });
                }

                HrMapToCompanyBM _ObjHMapCompanyModel = _candidatesvc.GetHrNCompanyMapDetailByCMapHrId(CompanyMapToHrId);

                var baseUrl = $"{this.Request.Host.Host.ToString()}";

                string url = "EmailFlg_" + baseUrl;

                string _AssesmentHostUrl = _mastersvc.GetConfigurationValueById(url);
                string TempURL = string.Empty;

                if (_ObjHMapCompanyModel.IsBulkLinkGenerationReq)
                {
                    for(int i =0;i<= _ObjHMapCompanyModel.CountOfLink-1;i++)
                    {
                        int TestId = _candidatesvc.SaveInitialCandidateData(CompanyMapToHrId, _ObjHMapCompanyModel.AssessmentId);

                        string URL = _AssesmentHostUrl + TestId;

                        TempURL = TempURL + "<a href=" + URL + " target='_self'>" + URL + "</a> <br/>";
                    }
                }
                else
                {
                    int TestId = _candidatesvc.SaveInitialCandidateData(CompanyMapToHrId, _ObjHMapCompanyModel.AssessmentId);

                    string URL = _AssesmentHostUrl + TestId;

                    TempURL = TempURL + "<a href=" + URL + " target='_self'>" + URL + "</a>";
                }
                MailBM objmailmodel = _mailsvc.GetMailDetailByUniqueId(CompanyMapToHrId, true, false);

                Task.Run(async () => await this._mailsvc.SentMail(objmailmodel, TempURL,true,false));

                return Ok(new { URL = TempURL, isSuccess = true });
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPost("SaveCandidateRecord")]
        public IActionResult SaveCandidateDetails(CandidateBM ObjCandidatemodel)
        {
            try
            {
                ObjCandidatemodel.DateOfBirth = ObjCandidatemodel.DateOfBirth == null ? (DateTime?)null : ObjCandidatemodel.DateOfBirth.Value.AddDays(1);
                if (_candidatesvc.IsDateDifferenceForOneYear(ObjCandidatemodel.CandidateId))
                {
                    return Ok(new
                    {
                        message = "Please Note : The link you clicked on has expired,as ie was valid for a duration of 15 days from the date of payment Please contact us at support@questaenneagram.com for further assistance. ",
                        isSuccess = false
                    });
                }
                else
                {
                    var CandidateData = _candidatesvc.SaveCandidateDetails(ObjCandidatemodel).Result;
                    bool IsSucess = CandidateData.Item2;
                    string Message = CandidateData.Item1;
                    if(IsSucess)
                    {
                        string token = CreateToken(ObjCandidatemodel.TestId.ToString(), ObjCandidatemodel.Email);
                        var _refreshToken = GenerateRefreshToken();
                        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMin);

                        _candidatesvc.InsertRefreshTokenBaseOnTestId(ObjCandidatemodel.TestId.Value, _refreshToken, DateTime.Now.AddMinutes(refreshTokenValidityInMin));

                        return Ok(new { TestId = ObjCandidatemodel.TestId, isSuccess = true, Token = token, RefreshToken = _refreshToken });
                    }
                    else
                    {
                        return Unauthorized(new { message = Message, isSuccess = false });
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPost("refresh-token")]
      //  [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }
            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                return BadRequest("Invalid access token or refresh token");
            }
            string TestId = principal.Identity.Name;

            var refreshTokenmodel = _candidatesvc.GetRefreshTokenDetailsBaseOnTestId(Convert.ToInt32(TestId));

            if (refreshTokenmodel == null || refreshTokenmodel.RefreshToken != refreshToken || refreshTokenmodel.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var newAccessToken = CreateToken(TestId, "");
            var newRefreshToken = GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMin);

            refreshTokenmodel.RefreshToken = newRefreshToken;
            refreshTokenmodel.RefreshTokenCreatedTime = DateTime.Now;
            refreshTokenmodel.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMin);
            _candidatesvc.UpdateRefreshToken(refreshTokenmodel);

            return Ok(new { TestId = TestId, isSuccess = true, Token = newAccessToken, RefreshToken = newRefreshToken });
        }



        private string CreateToken(string TestId,string email)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, TestId),
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Role, "Candidate")
            };


            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }
    }
}
