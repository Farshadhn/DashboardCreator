using #ProjectName.Core.Infrastructure.#ModelAdd;
using #ProjectName.Core.MainCore.#ModelAdd;
using #ProjectName.Data.Contracts;
using #ProjectName.Service.Services.Base;
using System;
using System.Linq;

namespace #ProjectName.Service.Services.#ModelAdd
{
    public class #ModelNameService : BaseService<#ModelName, Guid>, I#ModelNameService//, IScopedDependency
    {
        private readonly IRepository<#ModelName> _repository;

        public #ModelNameService(IRepository<#ModelName> repository) : base(repository)
        {
            _repository = repository;
        }
        
    }
}
