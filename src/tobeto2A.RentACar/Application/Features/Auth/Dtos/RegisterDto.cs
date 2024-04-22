using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Dtos;
public class RegisterDto
{
    public UserForRegisterDto  User { get; set; }
    // ... diğer verilecek kayıt bilgileri
    public string Address { get; set; }
    public string TaxNo { get; set; }
}
