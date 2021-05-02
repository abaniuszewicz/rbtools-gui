using RBTools.Application.Communication.DTO;
using RBTools.Application.Communication.Mapping;
using RBTools.Application.Config;

namespace RBTools.Application
{
    public class PostCommandIssuer : CommandIssuer
    {
        public PostCommandIssuer(IConfiguration settings) 
            : base(settings)
        {
        }

        public void Issue(RbtPostDto dto)
        {
            var command = dto.AsPostCommand();
            Issue(command);
        }
    }
}