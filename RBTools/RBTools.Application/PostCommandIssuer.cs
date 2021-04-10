using RBTools.Application.Communication.DTO;
using RBTools.Application.Communication.Mapping;

namespace RBTools.Application
{
    public class PostCommandIssuer : CommandIssuer
    {
        public PostCommandIssuer(string root) 
            : base(root)
        {
        }

        public void Issue(RbtPostDto dto)
        {
            var command = dto.AsPostCommand();
            Issue(command);
        }
    }
}