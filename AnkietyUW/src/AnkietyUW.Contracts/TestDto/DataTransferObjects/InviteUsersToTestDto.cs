using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Contracts.TestDto.DataTransferObjects
{
    public class InviteUsersToTestDto
    {
        public Guid TestId { get; set; }
        public List<string> EmailAddressList { get; set; }

    }
}
