﻿using Innohoot.DTO;
using Innohoot.Models.Activity;

namespace Innohoot.DataLayer.Services.Implementations;

public interface IPollService
{
	Task<Guid> Create(PollDTO pollDTO);
	Task Update(PollDTO pollDTO);
	Task Delete(Guid Id);
	Task<PollDTO?> Get(Guid Id);
	Task<List<PollDTO>> GetAllPollsByPollCollectionId(Guid pollCollectionId);
}