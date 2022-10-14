using AutoMapper;
using JSMClientsRegistries.Application.Models.Requests;
using JSMClientsRegistries.Application.Models.Responses;
using JSMClientsRegistries.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSMClientsRegistries.Application.UseCases
{
    public class ElegibleListUseCase : IUseCaseAsync<ElegibleListRequest, IActionResult>
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ElegibleListUseCase(IClientRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> ExecuteAsync(ElegibleListRequest request, int pageNumber, int pageSize)
        {
            if (request == null)
                return new BadRequestResult();

            var clients = await _repository.ElegibleList(request.Region, request.Type, pageNumber, pageSize);

            PaginationResponse pagination = new()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = await _repository.CountElegibleList(request.Region, request.Type),
                Users = _mapper.Map<List<ClientResponse>>(clients)
            };

            return new OkObjectResult(pagination);
        }
    }
}
