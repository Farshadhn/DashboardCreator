using AutoMapper;
using #ProjectName.Api.Models.#ModelAdd;
using #ProjectName.Core.Infrastructure.#ModelAdd;
using #ProjectName.Core.MainCore.#ModelAdd;
using #ProjectName.WebFramework.Api;

namespace #ProjectName.Api.Controllers.V1
{
    public class #ModelNameController : CrudController<#ModelNameDto, #ModelNameSelectDto, #ModelName, I#ModelNameService>
    {
        private readonly IMapper _mapper;
        public #ModelNameController(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }

    }
}
