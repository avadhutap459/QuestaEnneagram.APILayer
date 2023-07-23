

namespace QuestaEnneagram.ServiceLayer.Model
{
    public class RefreshTokenBM
    {
        public int RefreshTokenId { get; set; }
        public int TestId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenCreatedTime { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
