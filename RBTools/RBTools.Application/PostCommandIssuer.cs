using RBTools.Application.Communication.DTO;
using RBTools.Application.Communication.Mapping;
using RBTools.Application.Configuration;

namespace RBTools.Application
{
    public class PostCommandIssuer : CommandIssuer
    {
        public PostCommandIssuer(ISettings settings) 
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