using RBTools.Application.Communication.DTO;
using RBTools.Application.Communication.Mapping;
using RBTools.Application.Config;
using RBTools.Domain.Commands;

namespace RBTools.Application.Commands
{
    public class PostCommandIssuer : CommandIssuer
    {
        private readonly IMapper<RbtPostDto, PostCommand> _mapper;

        public PostCommandIssuer(IConfiguration settings, IMapper<RbtPostDto, PostCommand> mapper)
            : base(settings)
        {
            _mapper = mapper;
        }

        public void Issue(RbtPostDto dto)
        {
            var command = _mapper.Map(dto);
            Issue(command);
        }
    }
}