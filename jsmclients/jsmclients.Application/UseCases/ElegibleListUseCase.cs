using AutoMapper;
using jsmclients.Application.Models.Requests;
using jsmclients.Application.Models.Responses;
using jsmclients.Core.Entities;
using jsmclients.Core.Enums;
using jsmclients.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsmclients.Application.UseCases
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

        public async Task<IActionResult> ExecuteAsync(ElegibleListRequest request)
        {
            if (request == null)
                return new BadRequestResult();

            string coordinates = GetType(request.Region, request.Type);

            var clients = await _repository.ElegibleList(request.Region, request.Type);

            var response = _mapper.Map<List<ClientResponse>>(clients);

            return new OkObjectResult(response);

            /*
            var response = _mapper.Map<List<ClientResponse>>(new List<Client>()
            {
                new Client()
                {
                    Id = 1,
                    Gender = "F",
                    TitleName = "sra",
                    FirstName = "Cleidenilda",
                    LastName = "Silva",
                    Email = "abc@def.com",
                    DobDate = DateTime.Now,
                    RegisteredDate = DateTime.Now,
                    Phone = "123",
                    Cel = "1234",
                    Nationality = "BR",
                    Location = new Location()
                    {
                        Id = 1,
                        Street = "abc",
                        City = "def",
                        State = "são paulo",
                        Postcode = 123,
                        Latitude = "-02.196998",
                        Longitude = "-46.361899",
                        TimezoneOffset = "+1:00",
                        TimezoneDescription = "Brussels, Copenhagen, Madrid, Paris"
                    },
                    Pictures = new Pictures()
                    {
                        Id = 1,
                        Large = "asdas",
                        Medium = "asdasf",
                        Thumbnail = "asgasgas"
                    }
                }
            });
             */

            return new OkObjectResult(response);
            
        }


    }
}
