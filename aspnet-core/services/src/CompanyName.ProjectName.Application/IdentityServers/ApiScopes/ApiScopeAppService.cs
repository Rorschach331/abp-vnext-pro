﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyName.ProjectName.IdentityServer;
using CompanyName.ProjectName.IdentityServers.ApiScopes.Dtos;
using CompanyName.ProjectName.Publics.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.ApiScopes;

namespace CompanyName.ProjectName.IdentityServers.ApiScopes
{
    public class ApiScopeAppService : ProjectNameAppService, IApiScopeAppService
    {
        private readonly IdenityServerApiScopeManager _idenityServerApiScopeManager;

        public ApiScopeAppService(IdenityServerApiScopeManager idenityServerApiScopeManager)
        {
            _idenityServerApiScopeManager = idenityServerApiScopeManager;
        }

        public async Task<PagedResultDto<ApiScopeOutput>> GetListAsync(PagingApiScopeListInput input)
        {
            var list = await _idenityServerApiScopeManager.GetListAsync(
                input.SkipCount,
                input.PageSize,
                input.Filter,
                false);
            var totalCount = await _idenityServerApiScopeManager.GetCountAsync(input.Filter);
            return new PagedResultDto<ApiScopeOutput>(totalCount,
                ObjectMapper.Map<List<ApiScope>, List<ApiScopeOutput>>(list));
        }

        public Task CreateAsync(CreateApiScopeInput input)
        {
            return _idenityServerApiScopeManager.CreateAsync(input.Name, input.DisplayName, input.Description,
                input.Enabled, input.Required, input.Emphasize, input.ShowInDiscoveryDocument);
        }

        public Task UpdateAsync(UpdateCreateApiScopeInput input)
        {
            return _idenityServerApiScopeManager.UpdateAsync(input.Name, input.DisplayName, input.Description,
                input.Enabled, input.Required, input.Emphasize, input.ShowInDiscoveryDocument);
        }

        public Task DeleteAsync(IdInput input)
        {
            return _idenityServerApiScopeManager.DeleteAsync(input.Id);
        }
    }
}