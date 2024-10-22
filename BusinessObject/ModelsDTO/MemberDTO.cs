using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.ModelsDTO
{
    public partial class MemberDTO
    {
        public int MemberId { get; set; }
        public string Email { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? City { get; set; }
        public string? Country { get; set; }

    }
}
