using RBToolsContextMenu.Application.Communication.DTO;
using RBToolsContextMenu.Application.Communication.Mapping;
using RBToolsContextMenu.Domain.Commands;

namespace RBToolsContextMenu.Application
{
    public class PostCommandIssuer : CommandIssuer
    {
        public PostCommandIssuer() 
            : base()
        {
        }

        public void Issue(RbtPostDto dto)
        {
            var command = dto.AsPostCommand();
            Issue(command);
        }
    }
}